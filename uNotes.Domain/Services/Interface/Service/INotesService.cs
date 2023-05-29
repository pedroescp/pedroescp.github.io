using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Service
{
    public interface INotesService : IService<Notes>
    {
        void AtualizarNotes(Notes notes);
        IEnumerable<Notes> ObterPorUsuario(Guid usuarioId, string texto);
        IEnumerable<Notes> ObterPorUsuarioArquivado(Guid usuarioId, string texto);
        IEnumerable<Notes> ObterPorUsuarioLixeira(Guid usuarioId, string texto);
        string RemoverLogica(Guid notaId);
        void ArquivarLogica(Guid notaId);
    }
}
