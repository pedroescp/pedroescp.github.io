using uNotes.Application.Requests.Tag;
using uNotes.Application.Responses.Tag;

namespace uNotes.Application.AppService.Interface
{
    public interface ITagAppService
    {
        TagAdicionarRequest Adicionar(TagAdicionarRequest user);
        string Atualizar(TagAtualizarRequest documento);
        void Remover(Guid id);
        IEnumerable<TagObterResponse> ObterTodos();
        TagObterResponse ObterPorId(Guid id);
    }
}
