using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Infra.Data.Repository
{
    public class ColaboradoresRepository : Repository<Colaboradores>, IColaboradoresRepository
    {
        public ColaboradoresRepository(uNotesContext context) : base(context)
        {
        }
    }
}
