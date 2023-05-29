using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Infra.Data.Repository
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(uNotesContext context) : base(context)
        {
        }
    }
}
