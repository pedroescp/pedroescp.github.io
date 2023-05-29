using uNotes.Application.Requests.Documentos;
using uNotes.Application.Responses.Documentos;

namespace uNotes.Application.AppService.Interface
{
    public interface IDocumentoAppService
    {
        DocumentoAdicionarRequest Adicionar(DocumentoAdicionarRequest user);
        Task<string> Atualizar(DocumentoAtualizarRequest documento);
        void Remover(Guid id);
        IEnumerable<DocumentoObterResponse> ObterTodos();
        IEnumerable<DocumentoObterResponse> ObterPorDescricao(string texto);
        DocumentoObterResponse ObterPorId(Guid id);
    }
}
