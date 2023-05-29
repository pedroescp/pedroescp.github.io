using Amazon.S3.Model;
using Amazon.S3;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using uNotes.Infra.CrossCutting.AWS.Interfaces;
using uNotes.Infra.CrossCutting.AWS.Models;
using Microsoft.Extensions.Configuration;

namespace uNotes.Infra.CrossCutting.AWS
{
    public class AWSS3Service : IAWSS3Service
    {
        public AmazonS3Client S3Client { get; set; }
        private readonly IConfiguration _config;
        private const string AWS_bucketName = "AWS_BUCKET_NAME";
        private const string AWS_default_folder = "AWS_DEFAULT_FOLDER";
        private const string AWS_section = "AWS";
        private const string AWS_access_key = "AWS_ACCESS_KEY";
        private const string AWS_secret_key = "AWS_SECRET_KEY";
        public AWSS3Service(IConfiguration config)
        {
            _config = config;
            S3Client = new AmazonS3Client(_config.GetSection(AWS_section).GetValue<string>(AWS_access_key),
                _config.GetSection(AWS_section).GetValue<string>(AWS_secret_key),
                Amazon.RegionEndpoint.USEast1);
        }

        public async Task<AnexoResponse> UploadArquivo(IFormFile arquivo)
        {
            try
            {
                var imagemId = Guid.NewGuid().ToString();
                MemoryStream ms = new();
                var fs = arquivo.OpenReadStream();
                fs.CopyTo(ms);
                var request = await S3Client.PutObjectAsync(new PutObjectRequest
                {
                    BucketName = _config.GetSection(AWS_section).GetValue<string>(AWS_bucketName),
                    Key = _config.GetSection(AWS_section).GetValue<string>(AWS_default_folder) + "/" + imagemId,
                    InputStream = ms,
                    ContentType = arquivo.ContentType
                });
                AnexoResponse result = new();
                result.Id = imagemId;
                result.NomeArquivo = arquivo.FileName;
                return result;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<GetObjectResponse> DownloadArquivo(Guid arquivoId)
        {
            try
            {
                var request = await S3Client.GetObjectAsync(new GetObjectRequest()
                {
                    BucketName = _config.GetSection(AWS_section).GetValue<string>(AWS_bucketName),
                    Key = _config.GetSection(AWS_section).GetValue<string>(AWS_default_folder) + "/" + arquivoId
                });

                if (request.ResponseStream == null)
                {
                    throw new("Arquivo não encontrado!");
                }

                return request;
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null
                    && (amazonS3Exception.ErrorCode.Equals("Chave de acesso invalida!") || amazonS3Exception.ErrorCode.Equals("Segurança Invalida!")))
                {
                    throw new Exception("Cheque as credenciais do AWS.");
                }
                else
                {
                    throw new Exception("Ocorreu um erro: " + amazonS3Exception.Message);
                }
            }
        }

        public async Task<bool> ExcluirArquivo(Guid arquivoId)
        {
            try
            {
                await S3Client.DeleteObjectAsync(new DeleteObjectRequest()
                {
                    BucketName = _config.GetSection(AWS_section).GetValue<string>(AWS_bucketName),
                    Key = _config.GetSection(AWS_section).GetValue<string>(AWS_default_folder) + "/" + arquivoId
                });
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
