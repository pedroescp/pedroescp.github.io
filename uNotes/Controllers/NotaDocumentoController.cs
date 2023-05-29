using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using uNotaDocumento.Application.AppService.Interface;
using uNotes.Api;
using uNotes.Application.AppService;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.NotaDocumentos;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotaDocumento.Api.Controllers
{
    [ApiController]
    [Route("nota-documento")]
    [Authorize]
    public class NotaDocumentoController : BaseController
    {
        private readonly INotaDocumentoAppService _notaDocumentoAppService;
        public NotaDocumentoController(INotaDocumentoAppService NotaDocumentoAppService, INotificador notificador, ILogger<NotaDocumentoController> logger) : base(notificador, logger)
        {
            _notaDocumentoAppService = NotaDocumentoAppService;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] NotaDocumentoAdicionarRequest NotaDocumento) => CustomPostResponse(_notaDocumentoAppService.Adicionar(NotaDocumento, Request.Headers[HeaderNames.Authorization]));

        [HttpPut]
        public IActionResult Atualizar([FromBody] NotaDocumentoAtualizarRequest NotaDocumento) => CustomPutResponse(_notaDocumentoAppService.Atualizar(NotaDocumento, Request.Headers[HeaderNames.Authorization]));

        [HttpDelete]
        public IActionResult Remover(Guid notaId) 
        {
            _notaDocumentoAppService.Remover(notaId);
            return CustomResponse();   
        }

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId(Guid id) => CustomPostResponse(_notaDocumentoAppService.ObterPorId(id));

        [HttpGet]
        public IActionResult ObterTodos() => CustomPostResponse(_notaDocumentoAppService.ObterTodos());
    }
}
