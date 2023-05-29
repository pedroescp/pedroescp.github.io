using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uNotes.Application.Responses.Anexo;
using uNotes.Infra.CrossCutting.AWS.Interfaces;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Api.Controllers
{
    [ApiController]
    [Route("anexo")]
    [Authorize]
    public class AnexoController : BaseController
    {
        private readonly IAWSS3Service _AWSS3Service;
        public AnexoController(IAWSS3Service awss3Service, INotificador notificador, ILogger<AnexoController> logger) : base(notificador, logger)
        {
            _AWSS3Service = awss3Service;
        }

        [HttpGet("obter-arquivo")]
        public IActionResult ObterArquivo([FromQuery] Guid arquivoId)
        {
            MemoryStream memoryStream = new();
            var request = _AWSS3Service.DownloadArquivo(arquivoId).Result;
            Stream responseStream = request.ResponseStream;
            responseStream.CopyTo(memoryStream);
            byte[] buffer = memoryStream.ToArray();
            var file = File((buffer), request.Headers.ContentType, "Anexo");
            return Ok(new ArquivoResponse(Convert.ToBase64String(buffer)));
        }

        [HttpGet("download-arquivo")]
        public IActionResult DownloadArquivo([FromQuery] Guid arquivoId)
        {
            MemoryStream memoryStream = new();
            var request = _AWSS3Service.DownloadArquivo(arquivoId).Result;
            Stream responseStream = request.ResponseStream;
            responseStream.CopyTo(memoryStream);
            byte[] buffer = memoryStream.ToArray();
            var file = File((buffer), request.Headers.ContentType, "Anexo");
            return Ok(new ArquivoResponse(Convert.ToBase64String(buffer), file));
        }
    }
}
