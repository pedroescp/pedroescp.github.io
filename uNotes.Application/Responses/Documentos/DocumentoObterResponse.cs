using uNotaDocumento.Application.AppService.Interface;
using uNotes.Application.Responses.NotaDocumentos;

namespace uNotes.Application.Responses.Documentos
{
    public class DocumentoObterResponse
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public Guid? CategoriaId { get; set; }
        public List<NotaDocumentosObterResponse> Notas { get; set; }
    }
}
