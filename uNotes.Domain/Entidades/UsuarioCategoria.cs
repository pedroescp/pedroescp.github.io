namespace uNotes.Domain.Entidades
{
    public class UsuarioCategoria
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid CategoriaId { get; set; }

        public Usuario Usuario { get; set; }
        public Categoria Categoria { get; set; }
    }
}
