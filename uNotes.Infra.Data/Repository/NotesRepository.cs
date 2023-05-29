using uNotes.Domain.Entidades;
using uNotes.Domain.Enumerators;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Infra.Data.Contexto;

namespace uNotes.Infra.Data.Repository
{
    public class NotesRepository : Repository<Notes>, INotesRepository
    {
        public NotesRepository(uNotesContext context) : base(context)
        {
        }

        public IEnumerable<Notes> ObterPorUsuarioTodos(Guid usuarioId, string texto)
        {
            return DbSet.Where(x => (string.IsNullOrEmpty(texto) || x.Texto.ToLower().Contains(texto.ToLower()) 
                                    || x.Titulo.ToLower().Contains(texto.ToLower()))
                                    && x.CriadorId == usuarioId 
                                    && x.DataExclusao == null 
                                    && (x.Status == StatusNota.Fixado || x.Status == StatusNota.Ativo))
                        .OrderByDescending(x => x.DataAtualizacao)
                        .ThenBy(x => x.Status);
        }

        public IEnumerable<Notes> ObterPorUsuarioArquivado(Guid usuarioId, string texto)
        {
            return DbSet.Where(x => (string.IsNullOrEmpty(texto) || x.Texto.ToLower().Contains(texto.ToLower())
                                    || x.Titulo.ToLower().Contains(texto.ToLower()))
                                    && x.CriadorId == usuarioId
                                    && x.DataExclusao == null
                                    && x.Status == StatusNota.Arquivada)
                        .OrderByDescending(x => x.DataAtualizacao)
                        .ThenBy(x => x.Status);
        }

        public IEnumerable<Notes> ObterPorUsuarioLixeira(Guid usuarioId, string texto)
        {
            return DbSet.Where(x => (string.IsNullOrEmpty(texto) || x.Texto.ToLower().Contains(texto.ToLower())
                                    || x.Titulo.ToLower().Contains(texto.ToLower()))
                                    && x.CriadorId == usuarioId
                                    && x.Status == StatusNota.Lixeira)
                        .OrderByDescending(x => x.DataAtualizacao)
                        .ThenBy(x => x.Status);
        }
    }
}
