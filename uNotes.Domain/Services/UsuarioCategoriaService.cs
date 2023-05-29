using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;

namespace uNotes.Domain.Services
{
    public class UsuarioCategoriaService : Service<UsuarioCategoria>, IUsuarioCategoriaService
    {
        public UsuarioCategoriaService(IUsuarioCategoriaRepository repository) : base(repository)
        {
        }
    }
}
