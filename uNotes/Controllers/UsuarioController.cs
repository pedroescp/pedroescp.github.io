using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Usuario;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Api
{
    [ApiController]
    [Authorize]
    [Route("usuario")]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioAppService _usuarioAppService;
        public UsuarioController(IUsuarioAppService usuarioAppService, INotificador notificador, ILogger<UsuarioController> logger) : base(notificador, logger)
        {
            _usuarioAppService = usuarioAppService;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Adicionar([FromBody] UsuarioAdicionarRequest usuario)
        {
            return CustomPostResponse(_usuarioAppService.Adicionar(usuario));
        }

        [HttpPost]
        [Route("adicionar-avatar")]
        public async Task<IActionResult> AdicionarAvatar([FromForm] UsuarioAdicionarAvatarRequest objeto) => CustomResponse(await _usuarioAppService.AdicionarAvatar(objeto.Arquivo, Request.Headers[HeaderNames.Authorization]));

        [HttpPut]
        public IActionResult Atualizar([FromBody] UsuarioAtualizarRequest usuario) => CustomPutResponse(_usuarioAppService.Atualizar(usuario));

        [AllowAnonymous]
        [HttpPost("autenticar")]
        public IActionResult Autenticar([FromBody] UsuarioAutenticarRequest usuario) => CustomResponse(_usuarioAppService.Autenticar(usuario));

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId() => CustomPostResponse(_usuarioAppService.ObterPorId(Request.Headers[HeaderNames.Authorization]));

        [HttpGet]
        public IActionResult ObterTodos() => CustomPostResponse(_usuarioAppService.ObterTodos());
    }
}