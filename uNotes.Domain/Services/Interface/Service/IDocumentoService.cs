using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Service
{
    public interface IDocumentoService : IService<Documento>
    {
        void Atualizar(Documento documento);
        Task AtualizarDocumento(Documento documento);
        IEnumerable<Documento> ObterPorDescricao(string texto);
    }
}
