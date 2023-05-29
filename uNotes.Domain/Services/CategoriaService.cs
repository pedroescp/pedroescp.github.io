using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;

namespace uNotes.Domain.Services
{
    public class CategoriaService : Service<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository repository) : base(repository)
        {
            _categoriaRepository = repository;
        }

        public void AtualizarCategoria(Categoria cargo)
        {
            var antigaCategoria = _categoriaRepository.ObterPorId(cargo.Id);
            antigaCategoria.Atualizar(cargo);
            return;
        }

        public List<Categoria> ObterCategoriasPorUsuario(Guid usuarioId)
        {
            return _categoriaRepository.ObterCategoriasPorUsuario(usuarioId);   
        }

        public Categoria ObterPorCategoriaPai(Guid categoriaPaiId)
        {
            return _categoriaRepository.ObterPorCategoriaPai(categoriaPaiId);
        }
    }
}
