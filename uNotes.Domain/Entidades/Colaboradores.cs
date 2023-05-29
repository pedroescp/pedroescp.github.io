namespace uNotes.Domain.Entidades
{
    public class Colaboradores : EntidadeBase
    {
        public string UsuarioId { get; set; }
        public string NotaId { get; set; }
        public string DocumentoId { get; set; }
        public string Status { get; set; }


        public void Atualizar(Colaboradores novoColaborador)
        {
            Status = novoColaborador.Status;
        }

    }
}
