using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Repository
{
    public interface INotesRepository : IRepository<Notes>
    {
        IEnumerable<Notes> ObterPorUsuarioTodos(Guid usuarioId, string texto);
        IEnumerable<Notes> ObterPorUsuarioArquivado(Guid usuarioId, string texto);
        IEnumerable<Notes> ObterPorUsuarioLixeira(Guid usuarioId, string texto);
    }
}
