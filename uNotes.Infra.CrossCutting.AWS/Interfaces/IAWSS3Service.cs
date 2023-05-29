using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using uNotes.Infra.CrossCutting.AWS.Models;

namespace uNotes.Infra.CrossCutting.AWS.Interfaces
{
    public interface IAWSS3Service
    {
        Task<AnexoResponse> UploadArquivo(IFormFile myfile);
        Task<GetObjectResponse> DownloadArquivo(Guid arquivoId);
        Task<bool> ExcluirArquivo(Guid arquivoId);
    }
}
