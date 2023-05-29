using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Documentos;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Api.Controllers
{
    [ApiController]
    [Route("documentos")]
    [Authorize]
    public class DocumentoController : BaseController
    {
        private readonly IDocumentoAppService _documentosAppService;
        public DocumentoController(IDocumentoAppService documentosAppService, INotificador notificador, ILogger<DocumentoController> logger) : base(notificador, logger)
        {
            _documentosAppService = documentosAppService;
        }

        [HttpGet("obter-por-texto")]
        public IActionResult ObterPorDescricao(string texto) => CustomPostResponse(_documentosAppService.ObterPorDescricao(texto));

        [HttpPost]
        public IActionResult Adicionar([FromBody] DocumentoAdicionarRequest notes) => CustomPostResponse(_documentosAppService.Adicionar(notes));

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] DocumentoAtualizarRequest notes) => CustomPutResponse(await _documentosAppService.Atualizar(notes));

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId(Guid id) => CustomPostResponse(_documentosAppService.ObterPorId(id));

        [HttpGet]
        public IActionResult ObterTodos() => CustomPostResponse(_documentosAppService.ObterTodos());

    }
}
