using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Notes;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Api.Controllers
{
    [ApiController]
    [Route("notes")]
    [Authorize]
    public class NotesController : BaseController
    {
        private readonly INotesAppService _notesAppService;
        public NotesController(INotesAppService notesAppService, INotificador notificador, ILogger<NotesController> logger) : base(notificador, logger)
        {
            _notesAppService = notesAppService;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] NotesAdicionarRequest notes) => CustomPostResponse(_notesAppService.Adicionar(notes, Request.Headers[HeaderNames.Authorization]));

        [HttpPut]
        public IActionResult Atualizar([FromBody] NotesAtualizarRequest notes) => CustomPutResponse(_notesAppService.Atualizar(notes, Request.Headers[HeaderNames.Authorization]));

        [HttpDelete]
        public IActionResult Remover(Guid notaId) => CustomDeleteResponse(_notesAppService.RemoverLogica(notaId));

        [HttpDelete("arquivar")]
        public IActionResult Arquivar(Guid notaId) => CustomDeleteResponse(_notesAppService.ArquivarLogica(notaId));

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId(Guid id) => CustomPostResponse(_notesAppService.ObterPorId(id));

        [HttpGet]
        public IActionResult ObterTodos() => CustomPostResponse(_notesAppService.ObterTodos());

        [HttpGet("obter-por-usuario")]
        public IActionResult ObterPorUsuario(string? texto) => CustomResponse(_notesAppService.ObterPorUsuario(Request.Headers[HeaderNames.Authorization], texto));

        [HttpGet("obter-por-usuario-arquivado")]
        public IActionResult ObterPorUsuarioArquivado(string? texto) => CustomResponse(_notesAppService.ObterPorUsuarioArquivado(Request.Headers[HeaderNames.Authorization], texto));

        [HttpGet("obter-por-usuario-lixeira")]
        public IActionResult ObterPorUsuarioLixeira(string? texto) => CustomResponse(_notesAppService.ObterPorUsuarioLixeira(Request.Headers[HeaderNames.Authorization], texto));
    }
}
