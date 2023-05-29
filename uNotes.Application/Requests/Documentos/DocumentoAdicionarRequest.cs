namespace uNotes.Application.Requests.Documentos
{
    public class DocumentoAdicionarRequest
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public Guid? CategoriaId { get; set; }

    }
}
