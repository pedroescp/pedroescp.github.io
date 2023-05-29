using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario? ObterPorEmailOuLogin(string usuario);
    }
}
