using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Notes;
using uNotes.Application.Responses.Notes;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.Notificacoes;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Application.AppService
{
    public class NotesAppService : BaseAppService, INotesAppService
    {
        private readonly INotesService _notesService;
        private readonly INotificador _notificador;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotesAppService(INotesService notesService, IUnitOfWork unitOfWork, IMapper mapper, INotificador notificador)
        {
            _notesService = notesService;
            _unitOfWork = unitOfWork;
            _notificador = notificador;
            _mapper = mapper;
        }

        public NotesAdicionarRequest Adicionar(NotesAdicionarRequest user, string token)
        {
            var usuarioId = ObterInformacoesToken(token[7..]);
            if (usuarioId == null || usuarioId == Guid.Empty)
            {
                _notificador.AdicionarNotificacao("Token inválido");
                return null;
            }
            user.CriadorId = usuarioId;
            user.UsuarioAtualizacaoId = usuarioId;
            _notesService.Adicionar(_mapper.Map<Notes>(user));
            _unitOfWork.Commit();
            return user;
        }

        public string Atualizar(NotesAtualizarRequest user, string token)
        {
            var usuarioId = ObterInformacoesToken(token[7..]);
            if (usuarioId == null || usuarioId == Guid.Empty)
            {
                _notificador.AdicionarNotificacao("Token inválido");
                return null;
            }
            user.CriadorId = usuarioId;
            user.UsuarioAtualizacaoId = usuarioId;
            _notesService.AtualizarNotes(_mapper.Map<Notes>(user));
            _unitOfWork.Commit();
            return "Notes Atualizado com Sucesso";
        }

        public NotesObterResponse ObterPorId(Guid id)
        {
            return _mapper.Map<NotesObterResponse>(_notesService.ObterPorId(id));
        }

        public IEnumerable<NotesObterResponse> ObterTodos()
        {
            return _mapper.Map<IEnumerable<NotesObterResponse>>(_notesService.ObterTodos());
        }

        public IEnumerable<NotesObterResponse> ObterPorUsuario(string token, string texto)
        {
            var usuarioId = ObterInformacoesToken(token[7..]);
            if (usuarioId == null || usuarioId == Guid.Empty)
            {
                _notificador.AdicionarNotificacao("Token inválido");
                return null;
            }
            return _mapper.Map<IEnumerable<NotesObterResponse>>(_notesService.ObterPorUsuario(usuarioId, texto));
        }

        public string RemoverLogica(Guid id)
        {
            string removerMensagem = _notesService.RemoverLogica(id);
            _unitOfWork.Commit();
            return removerMensagem;
        }

        public IEnumerable<Notes> ObterPorUsuarioLixeira(string token, string texto)
        {
            var usuarioId = ObterInformacoesToken(token[7..]);
            if (usuarioId == null || usuarioId == Guid.Empty)
            {
                _notificador.AdicionarNotificacao("Token inválido");
                return null;
            }
            return _notesService.ObterPorUsuarioLixeira(usuarioId, texto);
        }

        public IEnumerable<Notes> ObterPorUsuarioArquivado(string token, string texto)
        {
            var usuarioId = ObterInformacoesToken(token[7..]);
            if (usuarioId == null || usuarioId == Guid.Empty)
            {
                _notificador.AdicionarNotificacao("Token inválido");
                return null;
            }
            return _notesService.ObterPorUsuarioArquivado(usuarioId, texto);
        }

        public string ArquivarLogica(Guid notaId)
        {
            _notesService.ArquivarLogica(notaId);
            if (_notificador.TemNotificacao())
                return null;
            _unitOfWork.Commit();
            return "Nota arquivada com sucesso";
        }
    }
}
