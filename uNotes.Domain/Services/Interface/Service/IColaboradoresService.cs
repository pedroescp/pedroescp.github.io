using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Service
{
    public interface IColaboradoresService : IService<Colaboradores>
    {
        void AtualizarColaboradores(Colaboradores colaboradores);
    }
}
