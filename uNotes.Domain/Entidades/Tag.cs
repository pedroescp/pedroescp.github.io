using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uNotes.Domain.Entidades
{
    public class Tag
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }

        public void Atualizar(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
