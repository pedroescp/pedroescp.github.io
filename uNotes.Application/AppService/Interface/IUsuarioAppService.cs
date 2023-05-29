using Microsoft.AspNetCore.Http;
using uNotes.Application.Requests.Usuario;
using uNotes.Application.Responses.Usuario;

namespace uNotes.Application.AppService.Interface
{
    public interface IUsuarioAppService
    {
        string Adicionar(UsuarioAdicionarRequest user);
        string Atualizar(UsuarioAtualizarRequest user);
        void Remover(Guid id);
        LoginObterResponse Autenticar(UsuarioAutenticarRequest usuario);
        IEnumerable<UsuarioObterResponse> ObterTodos();
        UsuarioObterResponse ObterPorId(string token);
        Task<string> AdicionarAvatar(IFormFile arquivo, string token);
    }
}
