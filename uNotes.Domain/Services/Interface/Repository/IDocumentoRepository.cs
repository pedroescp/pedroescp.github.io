using uNotes.Domain.Entidades;

namespace uNotes.Domain.Services.Interface.Repository
{
    public interface IDocumentoRepository : IRepository<Documento>
    {
        IEnumerable<Documento> ObterPorDescricao(string texto);
    }
}
