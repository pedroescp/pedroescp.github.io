using AutoMapper;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Colaboradores;
using uNotes.Application.Responses.Colaboradores;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Application.AppService
{
    public class ColaboradoresAppService : IColaboradoresAppService
    {
        private readonly IColaboradoresService _colaboradoreService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColaboradoresAppService(IColaboradoresService colaboradoresService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _colaboradoreService = colaboradoresService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ColaboradoresAdicionarRequest Adicionar(ColaboradoresAdicionarRequest user)
        {
            _colaboradoreService.Adicionar(_mapper.Map<Colaboradores>(user));
            _unitOfWork.Commit();
            return user;
        }

         public string Atualizar(ColaboradoresAtualizarRequest user)
        {
            _colaboradoreService.AtualizarColaboradores(_mapper.Map<Colaboradores>(user));
            _unitOfWork.Commit();
            return "Notes Atualizado com Sucesso";
        }
        
        public ColaboradoresObterResponse ObterPorId(Guid id)
        {
            return _mapper.Map<ColaboradoresObterResponse>(_colaboradoreService.ObterPorId(id));
        }

        public IEnumerable<ColaboradoresObterResponse> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ColaboradoresObterResponse>>(_colaboradoreService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _colaboradoreService.Remover(id);
            _unitOfWork.Commit();
        }
    }
}
