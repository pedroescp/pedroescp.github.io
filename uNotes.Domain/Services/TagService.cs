using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;

namespace uNotes.Domain.Services
{
    public class TagService : Service<Tag>, ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository repository) : base(repository)
        {
            _tagRepository = repository;
        }

        public void AtualizarTag(Tag tag)
        {
            var antigaTag = _tagRepository.ObterPorId(tag.Id);
            antigaTag.Atualizar(tag);
            return;
        }
    }
}
