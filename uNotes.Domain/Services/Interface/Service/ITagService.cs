using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Service
{
    public interface ITagService : IService<Tag>
    {
        void AtualizarTag(Tag tag);
    }
}
