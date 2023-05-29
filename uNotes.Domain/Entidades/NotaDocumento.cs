using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uNotes.Domain.Enumerators;

namespace uNotes.Domain.Entidades
{
    public class NotaDocumento : EntidadeBase
    {
        protected NotaDocumento() { }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public Guid CriadorId { get; set; }
        public StatusNota Status { get; set; }
        public Guid UsuarioAtualizacaoId { get; set; }
        public Guid? DocumentoId { get; set; }
        public virtual Documento? Documento { get; set; }


        public void Atualizar(NotaDocumento notaDocumento)
        {
            Titulo = notaDocumento.Titulo;
            Texto = notaDocumento.Texto;
            Status = notaDocumento.Status;
            UsuarioAtualizacaoId = notaDocumento.UsuarioAtualizacaoId;
        }    
    }

}
