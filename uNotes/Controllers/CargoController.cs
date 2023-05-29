using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Cargo;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Api.Controllers
{
    [ApiController]
    [Route("cargo")]
    [Authorize]
    public class CargoController : BaseController
    {
        private readonly ICargoAppService _cargoAppService;
        public CargoController(ICargoAppService cargoAppService, INotificador notificador, ILogger<CargoController> logger) : base(notificador, logger)
        {
            _cargoAppService = cargoAppService;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] CargoAdicionarRequest usuario) => CustomPostResponse(_cargoAppService.Adicionar(usuario));

        [HttpPut]
        public IActionResult Atualizar([FromBody] CargoAtualizarRequest usuario) => CustomPutResponse(_cargoAppService.Atualizar(usuario));

        [HttpGet("obter-por-id")]
        public IActionResult ObterPorId(Guid id) => CustomPostResponse(_cargoAppService.ObterPorId(id));

        [HttpGet]
        public IActionResult ObterTodos() => CustomPostResponse(_cargoAppService.ObterTodos());
    }
}
