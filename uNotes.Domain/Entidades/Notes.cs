using uNotes.Domain.Enumerators;

namespace uNotes.Domain.Entidades
{
    public class Notes : EntidadeBase
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public Guid CriadorId { get; set; }
        public StatusNota Status { get; set; }
        public Guid UsuarioAtualizacaoId { get; set; }

        public void Atualizar(Notes novoNotes)
        {
            Titulo = novoNotes.Titulo;
            Texto = novoNotes.Texto;
            UsuarioAtualizacaoId = novoNotes.UsuarioAtualizacaoId;
            DataAtualizacao = DateTime.Now;
        }

        public void RemoverLogica()
        {
            DataExclusao = DateTime.Now;
            Status = StatusNota.Lixeira;
        }

        public void ReverterRemocao()
        {
            DataExclusao = null;
            DataAtualizacao = DateTime.Now;
            Status = StatusNota.Ativo;
        }

        public void ArquivarLogica()
        {
            DataAtualizacao = DateTime.Now;
            Status = StatusNota.Arquivada;
        }

        public void ReverterArquivar()
        {
            DataAtualizacao = DateTime.Now;
            Status = StatusNota.Ativo;
        }
    }
}
