using Microsoft.EntityFrameworkCore;
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
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(uNotesContext context) : base(context)
        {
        }

        public Usuario? ObterPorEmailOuLogin(string usuario)
        {
            return DbSet
                    .Include(x => x.Cargo)
                    .FirstOrDefault(x => x.Email == usuario || x.Login == usuario);
        }
    }
}
