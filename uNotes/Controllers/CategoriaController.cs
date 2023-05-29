using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using uNotaDocumento.Application.AppService.Interface;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Categorias;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Api.Controllers
{
    [ApiController]
    [Route("categoria")]
    [Authorize]
    public class CategoriaController : BaseController
    {
        private readonly ICategoriaAppService _categoriaAppService;
        public CategoriaController(ICategoriaAppService categoriaAppService, INotificador notificador, ILogger<CategoriaController> logger) : base(notificador, logger)
        {
            _categoriaAppService = categoriaAppService;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] CategoriaAdicionarRequest usuario) => CustomPostResponse(_categoriaAppService.Adicionar(usuario, Request.Headers[HeaderNames.Authorization]));

        [HttpPut]
        public IActionResult Atualizar([FromBody] CategoriaAtualizarRequest usuario) => CustomPutResponse(_categoriaAppService.Atualizar(usuario));

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId(Guid id) => CustomPostResponse(_categoriaAppService.ObterPorId(id));

        [HttpGet]
        public IActionResult ObterTodos() => CustomPostResponse(_categoriaAppService.ObterTodos());

        [HttpGet("obter-por-usuario")]
        public IActionResult ObterCategoriasPorUsuario() => CustomPostResponse(_categoriaAppService.ObterCategoriasPorUsuario(Request.Headers[HeaderNames.Authorization]));

        [HttpDelete]
        public IActionResult Remover(Guid notaId)
        {
            _categoriaAppService.Remover(notaId);
            return CustomResponse();
        }

        [HttpPut("adicionar-usuarios")]
        public IActionResult AdicionarUsuarios([FromBody] CategoriasAdicionarUsuarioRequest usuarios) => CustomPutResponse(_categoriaAppService.AdicionarUsuarios(usuarios.CategoriaId, usuarios.Usuarios, Request.Headers[HeaderNames.Authorization]));

        [HttpPut("remover-usuarios")]
        public IActionResult RemoverUsuarios([FromBody] CategoriasAdicionarUsuarioRequest usuarios) => CustomPutResponse(_categoriaAppService.RemoverUsuarios(usuarios.CategoriaId, usuarios.Usuarios, Request.Headers[HeaderNames.Authorization]));
    }
}
