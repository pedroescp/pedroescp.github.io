using AutoMapper;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Cargo;
using uNotes.Application.Responses.Cargo;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Application.AppService
{
    public class CargoAppService : ICargoAppService
    {
        private readonly ICargoService _cargoService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CargoAppService(ICargoService cargoService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _cargoService = cargoService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public CargoAdicionarRequest Adicionar(CargoAdicionarRequest user)
        {
            _cargoService.Adicionar(_mapper.Map<Cargo>(user));
            _unitOfWork.Commit();
            return user;
        }

        public string Atualizar(CargoAtualizarRequest user)
        {
            _cargoService.AtualizarCargo(_mapper.Map<Cargo>(user));
            _unitOfWork.Commit();
            return "Cargo Atualizado com Sucesso";
        }

        public CargoObterResponse ObterPorId(Guid id)
        {
            return _mapper.Map<CargoObterResponse>(_cargoService.ObterPorId(id));
        }

        public IEnumerable<CargoObterResponse> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CargoObterResponse>>(_cargoService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _cargoService.Remover(id);
            _unitOfWork.Commit();
        }
    }
}
