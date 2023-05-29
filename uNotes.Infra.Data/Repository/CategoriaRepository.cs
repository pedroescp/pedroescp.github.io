using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Infra.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(uNotesContext context) : base(context)
        {
        }

        public List<Categoria> ObterCategoriasPorUsuario(Guid usuarioId)
        {
            var cat = DbSet.Include(x => x.Usuarios).ToList();
            var teste = DbSet
                    .Include(x => x.Usuarios)
                    .Where(x => x.Usuarios.Any(x => x.UsuarioId == usuarioId)).ToList();
            return teste;
        }

        public Categoria ObterPorCategoriaPai(Guid categoriaPaiId)
        {
            return DbSet.FirstOrDefault(x => x.Id == categoriaPaiId);
        }
    }
}
