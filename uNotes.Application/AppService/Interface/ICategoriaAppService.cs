using uNotes.Application.Requests.Categorias;
using uNotes.Application.Responses.Categorias;

namespace uNotes.Application.AppService.Interface
{
    public interface ICategoriaAppService
    {
        CategoriaAdicionarRequest Adicionar(CategoriaAdicionarRequest categoria, string token);
        string Atualizar(CategoriaAtualizarRequest categoria);
        void Remover(Guid id);
        IEnumerable<CategoriaObterResponse> ObterTodos();
        CategoriaObterResponse ObterPorId(Guid id);
        List<CategoriaObterResponse> ObterCategoriasPorUsuario(string token);
        string AdicionarUsuarios(Guid categoriaId, List<Guid> usuarioAdicionarId, string token);
        string RemoverUsuarios(Guid categoriaId, List<Guid> usuarioRemoverIds, string token);
    }
}
