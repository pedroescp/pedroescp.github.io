using uNotes.Application.Requests.Colaboradores;
using uNotes.Application.Responses.Colaboradores;

namespace uNotes.Application.AppService.Interface
{
    public interface IColaboradoresAppService
    {
        ColaboradoresAdicionarRequest Adicionar(ColaboradoresAdicionarRequest user);

        string Atualizar(ColaboradoresAtualizarRequest user);
        void Remover(Guid id);

        IEnumerable<ColaboradoresObterResponse> ObterTodos();

        ColaboradoresObterResponse ObterPorId(Guid id);
    }
}
