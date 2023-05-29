using Microsoft.EntityFrameworkCore;
using System.Text;
using uNotes.Domain.Entidades;
using uNotes.Domain.Enumerators;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Infra.Data.Contexto;
using uNotes.Infra.CrossCutting.Utils;

namespace uNotes.Infra.Data.Repository
{
    public class DocumentoRepository : Repository<Documento>, IDocumentoRepository
    {
        public DocumentoRepository(uNotesContext context) : base(context)
        {
        }

        public override IEnumerable<Documento> ObterTodos()
        {
            return DbSet.Include(x => x.Notas);
        }

        public IEnumerable<Documento> ObterPorDescricao(string texto)
        {   
            return DbSet.Where(x => x.Texto != null && x.Texto.ToLower().Contains(texto.ToLower()) 
                                || x.Titulo.ToLower().Contains(texto.ToLower()))
                .OrderBy(x => x.DataAtualizacao)
                .ToList();
        }
    }
}
