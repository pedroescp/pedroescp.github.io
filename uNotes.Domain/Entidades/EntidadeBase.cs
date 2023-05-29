namespace uNotes.Domain.Entidades
{
    public class EntidadeBase
    {
        public EntidadeBase()
        {
            Id = Guid.NewGuid();
            DataInclusao = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataExclusao { get; set; }

        public void AtualizarEntidade() => DataAtualizacao = DateTime.Now;

        public void MarcarComoRemovido() => DataExclusao = DateTime.Now;
    }
}
