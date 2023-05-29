using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.TagsNotas;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Api.Controllers
{
    [ApiController]
    [Route("tagsNotas")]
    [Authorize]
    public class TagsNotasController : BaseController
    {
        private readonly ITagsNotasAppService _tagsNotasAppService;
        public TagsNotasController(ITagsNotasAppService tagsNotasAppService, INotificador notificador, ILogger<TagsNotasController> logger) : base(notificador, logger)
        {
            _tagsNotasAppService = tagsNotasAppService;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] TagsNotasAdicionarRequest usuario) => CustomPostResponse(_tagsNotasAppService.Adicionar(usuario));
        
        [HttpPut]
        public IActionResult Atualizar([FromBody] TagsNotasAtualizarRequest usuario) => CustomPutResponse(_tagsNotasAppService.Atualizar(usuario));

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId(Guid id) => CustomResponse(_tagsNotasAppService.ObterPorId(id));

        [HttpGet]
        public IActionResult ObterTodos() => CustomResponse(_tagsNotasAppService.ObterTodos());
    }
}
