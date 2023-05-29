using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Colaboradores;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Api.Controllers
{
    [ApiController]
    [Route("colaboradores")]
    [Authorize]
    public class ColaboradoresController : BaseController
    {
        private readonly IColaboradoresAppService _colaboradoresAppService;
        public ColaboradoresController(IColaboradoresAppService colaboradoresAppService, INotificador notificador, ILogger<ColaboradoresController> logger) : base(notificador, logger)
        {
            _colaboradoresAppService = colaboradoresAppService;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Adicionar([FromBody] ColaboradoresAdicionarRequest usuario) => CustomPostResponse(_colaboradoresAppService.Adicionar(usuario));

        [HttpPut]
        public IActionResult Atualizar([FromBody] ColaboradoresAtualizarRequest usuario) => CustomPutResponse(_colaboradoresAppService.Atualizar(usuario));

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId(Guid id) => CustomPostResponse(_colaboradoresAppService.ObterPorId(id));

        [HttpGet]
        public IActionResult ObterTodos() => CustomPostResponse(_colaboradoresAppService.ObterTodos());
    }
}
