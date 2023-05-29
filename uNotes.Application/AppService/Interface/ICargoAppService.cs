using uNotes.Application.Requests.Cargo;
using uNotes.Application.Responses.Cargo;

namespace uNotes.Application.AppService.Interface
{
    public interface ICargoAppService
    {
        CargoAdicionarRequest Adicionar(CargoAdicionarRequest user);
        string Atualizar(CargoAtualizarRequest user);
        void Remover(Guid id);
        IEnumerable<CargoObterResponse> ObterTodos();
        CargoObterResponse ObterPorId(Guid id);
    }
}
