using AutoMapper;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Tag;
using uNotes.Application.Responses.Tag;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Application.AppService
{
    public class TagAppService : ITagAppService
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TagAppService(ITagService tagService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _tagService = tagService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public TagAdicionarRequest Adicionar(TagAdicionarRequest user)
        {
            _tagService.Adicionar(_mapper.Map<Tag>(user));
            _unitOfWork.Commit();
            return user;
        }
        public string Atualizar(TagAtualizarRequest user)
        {
            _tagService.AtualizarTag(_mapper.Map<Tag>(user));
            _unitOfWork.Commit();
            return "Tag Atualizada com Sucesso";
        }

        public TagObterResponse ObterPorId(Guid id)
        {
            return _mapper.Map<TagObterResponse>(_tagService.ObterPorId(id));
        }

        public IEnumerable<TagObterResponse> ObterTodos()
        {
            return _mapper.Map<IEnumerable<TagObterResponse>>(_tagService.ObterTodos());
        }
        public void Remover(Guid id)
        {
            _tagService.Remover(id);
            _unitOfWork.Commit();
        }
    }
}
