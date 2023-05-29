using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        List<Categoria> ObterCategoriasPorUsuario(Guid usuarioId);
        Categoria ObterPorCategoriaPai(Guid categoriaPaiId);
    }
}
