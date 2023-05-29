using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Service
{
    public interface ICargoService : IService<Cargo>
    {
        void AtualizarCargo(Cargo cargo);
    }
}
