namespace uNotes.Application.Requests.Categorias
{
    public class CategoriaAtualizarRequest
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public Guid? CategoriaPai { get; set; }
    }
}
