using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Service
{
    public interface ICategoriaService : IService<Categoria>
    {
        void AtualizarCategoria(Categoria cargo);
        List<Categoria> ObterCategoriasPorUsuario(Guid usuarioId);
        Categoria ObterPorCategoriaPai(Guid categoriaPaiId);
    }
}
