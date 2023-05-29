using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Infra.Data.Repository
{
    public class TagsNotasRepository : Repository<TagsNotas>, ITagsNotasRepository
    {
        public TagsNotasRepository(uNotesContext context) : base(context)
        {
        }
    }
}
