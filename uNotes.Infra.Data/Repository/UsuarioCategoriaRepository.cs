using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Infra.Data.Repository
{
    public class UsuarioCategoriaRepository : Repository<UsuarioCategoria>, IUsuarioCategoriaRepository
    {
        public UsuarioCategoriaRepository(uNotesContext context) : base(context)
        {
        }
    }
}
