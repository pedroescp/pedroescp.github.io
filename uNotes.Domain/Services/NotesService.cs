using uNotes.Domain.Entidades;
using uNotes.Domain.Enumerators;
using uNotes.Domain.Services.Interface.Repository;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.Notificacoes;

namespace uNotes.Domain.Services
{
    public class NotesService : Service<Notes>, INotesService
    {
        private readonly INotesRepository _notesRepository;
        private readonly INotificador _notificador;
        public NotesService(INotesRepository repository, INotificador notificador) : base(repository)
        {
            _notesRepository = repository;
            _notificador = notificador;
        }

        public void AtualizarNotes(Notes notes)
        {
            var antigoNotes = _notesRepository.ObterPorId(notes.Id);
            antigoNotes.Atualizar(notes);
            return;
        }

        public IEnumerable<Notes> ObterPorUsuario(Guid usuarioId, string texto)
        {
            return _notesRepository.ObterPorUsuarioTodos(usuarioId, texto);
        }

        public IEnumerable<Notes> ObterPorUsuarioArquivado(Guid usuarioId, string texto)
        {
            return _notesRepository.ObterPorUsuarioArquivado(usuarioId, texto);
        }

        public IEnumerable<Notes> ObterPorUsuarioLixeira(Guid usuarioId, string texto)
        {
            return _notesRepository.ObterPorUsuarioLixeira(usuarioId, texto);
        }

        public string RemoverLogica(Guid notaId)
        {
            var nota = _notesRepository.ObterPorId(notaId);
            if (nota == null)
                return "Nota não encontrada";
            if(nota.Status == StatusNota.Lixeira)
            {
                nota.ReverterRemocao();
            }
            else
            {
                nota.RemoverLogica();
            }
            return "Nota removida com sucesso";
        }

        public void ArquivarLogica(Guid notaId)
        {
            var nota = _notesRepository.ObterPorId(notaId);
            if (nota == null)
            {
                _notificador.AdicionarNotificacao("Nota não encontrada");
                return;
            }
            if(nota.Status == StatusNota.Arquivada)
            {
                nota.ReverterArquivar();
            }
            else
            {
                nota.ArquivarLogica();
            }     
        }
    }
}

