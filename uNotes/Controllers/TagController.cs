using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Tag;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Api.Controllers
{
    [ApiController]
    [Route("tag")]
    [Authorize]
    public class TagController : BaseController
    {
        private readonly ITagAppService _tagAppService;
        public TagController(ITagAppService tagAppService, INotificador notificador, ILogger<TagController> logger) : base(notificador, logger)
        {
            _tagAppService = tagAppService;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] TagAdicionarRequest usuario) => CustomPostResponse(_tagAppService.Adicionar(usuario));

        [HttpPut]
        public IActionResult Atualizar([FromBody] TagAtualizarRequest usuario) => CustomPutResponse(_tagAppService.Atualizar(usuario));

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId(Guid id) => CustomPostResponse(_tagAppService.ObterPorId(id));

        [HttpGet]
        public IActionResult ObterTodos() => CustomPostResponse(_tagAppService.ObterTodos());
    }
}
