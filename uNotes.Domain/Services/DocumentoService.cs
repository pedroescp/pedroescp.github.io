using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;

namespace uNotes.Domain.Services
{
    public class DocumentoService : Service<Documento>, IDocumentoService
    {
        private readonly IDocumentoRepository _documentoRepository;
        public DocumentoService(IDocumentoRepository repository) : base(repository)
        {
            _documentoRepository = repository;
        }

        public async Task AtualizarDocumento(Documento documento)
        {
            var antigoDocumento = _documentoRepository.ObterPorId(documento.Id);
            await antigoDocumento.Atualizar(documento);
            return;
        }

        public IEnumerable<Documento> ObterPorDescricao(string texto)
        {
            return _documentoRepository.ObterPorDescricao(texto);
        }
    }
}
