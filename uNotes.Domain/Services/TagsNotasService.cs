using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;

namespace uNotes.Domain.Services
{
    public class TagsNotasService : Service<TagsNotas>, ITagsNotasService
    {
        private readonly ITagsNotasRepository _tagsNotasRepository;

        public TagsNotasService(ITagsNotasRepository repository) : base(repository)
        {
            _tagsNotasRepository = repository;
        }

        public void AtualizarTagsNotas(TagsNotas tagsNotas)
        {
            var antigasTagsNotas = _tagsNotasRepository.ObterPorId(tagsNotas.Id);
            antigasTagsNotas.Atualizar(tagsNotas);
            return;
        }

    }
}
