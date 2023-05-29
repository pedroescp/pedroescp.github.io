using AutoMapper;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.TagsNotas;
using uNotes.Application.Responses.TagsNotas;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Application.AppService
{
    public class TagsNotasAppService : ITagsNotasAppService
    {
        private readonly ITagsNotasService _tagsNotasService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TagsNotasAppService(ITagsNotasService tagsNotasService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _tagsNotasService = tagsNotasService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public TagsNotasAdicionarRequest Adicionar(TagsNotasAdicionarRequest user)
        {
            _tagsNotasService.Adicionar(_mapper.Map<TagsNotas>(user));
            _unitOfWork.Commit();
            return user;
        }
        public string Atualizar(TagsNotasAtualizarRequest user)
        {
            _tagsNotasService.AtualizarTagsNotas(_mapper.Map<TagsNotas>(user));
            _unitOfWork.Commit();
            return "Tag Atualizada com Sucesso";
        }
        public TagsNotasObterResponse ObterPorId(Guid id)
        {
            return _mapper.Map<TagsNotasObterResponse>(_tagsNotasService.ObterPorId(id));
        }

        public IEnumerable<TagsNotasObterResponse> ObterTodos()
        {
            return _mapper.Map<IEnumerable<TagsNotasObterResponse>>(_tagsNotasService.ObterTodos());
        }
        public void Remover(Guid id)
        {
            _tagsNotasService.Remover(id);
            _unitOfWork.Commit();
        }
    }
}
