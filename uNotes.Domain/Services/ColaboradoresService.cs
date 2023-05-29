using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;

namespace uNotes.Domain.Services
{
    public class ColaboradoresService : Service<Colaboradores>, IColaboradoresService
    {
        private readonly IColaboradoresRepository _colaboradoresRepository;

        public ColaboradoresService(IColaboradoresRepository repository) : base(repository)
        {
            _colaboradoresRepository = repository;
        }
        public void AtualizarColaboradores(Colaboradores colaboradores)
        {
            var antigoNotes = _colaboradoresRepository.ObterPorId(colaboradores.Id);
            antigoNotes.Atualizar(colaboradores);
            return;
        }

    }
}
