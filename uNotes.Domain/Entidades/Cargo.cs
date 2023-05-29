namespace uNotes.Domain.Entidades
{
    public class Cargo : EntidadeBase
    {
        public Cargo(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public void Atualizar(Cargo cargo)
        {
            Nome = cargo.Nome;
            Descricao = cargo.Descricao;
        }

        internal void Atualizar(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
