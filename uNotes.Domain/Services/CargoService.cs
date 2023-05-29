using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;

namespace uNotes.Domain.Services
{
    public class CargoService : Service<Cargo>, ICargoService
    {
        private readonly ICargoRepository _cargoRepository;
        public CargoService(ICargoRepository repository) : base(repository)
        {
            _cargoRepository = repository;
        }

        public void AtualizarCargo(Cargo cargo)
        {
            var antigoCargo = _cargoRepository.ObterPorId(cargo.Id);
            antigoCargo.Atualizar(cargo);
            return;
        }
    }
}
