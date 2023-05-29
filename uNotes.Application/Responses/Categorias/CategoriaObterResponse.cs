using uNotes.Domain.Entidades;

namespace uNotes.Application.Responses.Categorias
{
    public class CategoriaObterResponse
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public Guid? CategoriaPai { get; set; }
        public List<Documento>? Documentos { get; set; }
    }
}
