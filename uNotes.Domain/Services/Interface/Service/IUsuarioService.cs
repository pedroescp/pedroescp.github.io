using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Service
{
    public interface IUsuarioService : IService<Usuario>
    {
        void AdicionarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
        Usuario? ObterUsuarioPorLoginOuEmail(string login);
        void AdicionarAvatar(Guid avatarId, Guid usuarioId);
        void RemoverAvatar(Guid usuarioId);
        string ExisteUsuario(Usuario usuario);
    }
}
