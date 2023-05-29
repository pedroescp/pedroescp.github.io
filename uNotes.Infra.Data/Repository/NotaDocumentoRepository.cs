using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Infra.Data.Repository
{
    public class NotaDocumentoRepository : Repository<NotaDocumento>, INotaDocumentoRepository
    {
        public NotaDocumentoRepository(uNotesContext context) : base(context)
        {
        }
    }
}
