using uNotes.Domain.Entidades;
using uNotes.Domain.Services;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotaDocumento.Domain.Services
{
    public class NotaDocumentoService : Service<NotaDocumento>, INotaDocumentoService
    {
        private readonly INotaDocumentoRepository _notaDocumentoRepository;
        private readonly INotificador _notificador;
        public NotaDocumentoService(INotaDocumentoRepository repository, INotificador notificador) : base(repository)
        {
            _notaDocumentoRepository = repository;
            _notificador = notificador;
        }

        public void AtualizarNotaDocumento(NotaDocumento notaDocumento)
        {
            var antigoNotaDocumento = _notaDocumentoRepository.ObterPorId(notaDocumento.Id);
            antigoNotaDocumento.Atualizar(notaDocumento);
            return;
        }
    }
}
