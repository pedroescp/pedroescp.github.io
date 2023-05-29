namespace uNotes.Domain.Entidades
{
    public class TagsNotas
    {
        public Guid Id { get; set; }
        public Guid NotaId { get; set; }
        public Guid TagId { get; set; }

        public void Atualizar(TagsNotas novoUsuario)
        {
           
            TagId = novoUsuario.TagId;
        }
    }
}
