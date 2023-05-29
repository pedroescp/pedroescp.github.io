using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Service
{
    public interface ITagsNotasService : IService<TagsNotas>
    {
        void AtualizarTagsNotas(TagsNotas tagsNotas);
    }
}
