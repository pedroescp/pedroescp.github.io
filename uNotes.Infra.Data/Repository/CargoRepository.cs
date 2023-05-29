using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Infra.Data.Repository
{
    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        public CargoRepository(uNotesContext context) : base(context)
        {
        }
    }
}
