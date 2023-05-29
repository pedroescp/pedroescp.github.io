using System.Runtime.CompilerServices;

namespace uNotes.Domain.Entidades
{
    public class Documento : EntidadeBase
    {
        public Documento()
        {

        }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public Guid CriadorId { get; set; }
        public bool Lixeira { get; set; }
        public Guid UsuarioAtualizacaoId { get; set; }
        public Guid? CategoriaId { get; set; }
        public virtual Categoria? Categoria { get; set; }
        public virtual List<NotaDocumento> Notas { get; set; }

        public async Task Atualizar(Documento novoDocumento)
        {
            Titulo = novoDocumento.Titulo;
            Texto = novoDocumento.Texto;
        }
    }
}
