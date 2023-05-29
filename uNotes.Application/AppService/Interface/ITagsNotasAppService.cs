using uNotes.Application.Requests.TagsNotas;
using uNotes.Application.Requests.Usuario;
using uNotes.Application.Responses.TagsNotas;
using uNotes.Domain.Entidades;

namespace uNotes.Application.AppService.Interface
{
    public interface ITagsNotasAppService
    {
        TagsNotasAdicionarRequest Adicionar(TagsNotasAdicionarRequest user);
        string Atualizar(TagsNotasAtualizarRequest user);
        void Remover(Guid id);
        IEnumerable<TagsNotasObterResponse> ObterTodos();
        TagsNotasObterResponse ObterPorId(Guid id);
    }
}
