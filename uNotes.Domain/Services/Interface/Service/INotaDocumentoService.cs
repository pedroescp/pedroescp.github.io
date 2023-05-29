using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Service
{
    public interface INotaDocumentoService : IService<NotaDocumento>
    {
        void AtualizarNotaDocumento(NotaDocumento notaDocumento);
    }
}
