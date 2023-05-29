using AutoMapper;
using uNotaDocumento.Application.AppService.Interface;
using uNotes.Application.Requests.NotaDocumentos;
using uNotes.Application.Responses.NotaDocumentos;
using uNotes.Application.Responses.Notes;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.Notificacoes;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Application.AppService
{
    public class NotaDocumentoAppService : BaseAppService, INotaDocumentoAppService
    {
        private readonly INotaDocumentoService _notaDocumentoService;
        private readonly INotificador _notificador;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotaDocumentoAppService(INotaDocumentoService notaDocumentoService, IUnitOfWork unitOfWork, IMapper mapper, INotificador notificador)
        {
            _notaDocumentoService = notaDocumentoService;
            _unitOfWork = unitOfWork;
            _notificador = notificador;
            _mapper = mapper;
        }

        public NotaDocumentoAdicionarRequest Adicionar(NotaDocumentoAdicionarRequest user, string token)
        {
            var usuarioId = ObterInformacoesToken(token[7..]);
            if (usuarioId == null || usuarioId == Guid.Empty)
            {
                _notificador.AdicionarNotificacao("Token inválido");
                return null;
            }
            user.CriadorId = usuarioId;
            user.UsuarioAtualizacaoId = usuarioId;
            _notaDocumentoService.Adicionar(_mapper.Map<NotaDocumento>(user));
            _unitOfWork.Commit();
            return user;
        }

        public string Atualizar(NotaDocumentoAtualizarRequest user, string token)
        {
            var usuarioId = ObterInformacoesToken(token[7..]);
            if (usuarioId == null || usuarioId == Guid.Empty)
            {
                _notificador.AdicionarNotificacao("Token inválido");
                return null;
            }
            user.CriadorId = usuarioId;
            user.UsuarioAtualizacaoId = usuarioId;
            _notaDocumentoService.AtualizarNotaDocumento(_mapper.Map<NotaDocumento>(user));
            _unitOfWork.Commit();
            return "Nota Atualizada com Sucesso";
        }

        public NotaDocumentosObterResponse ObterPorId(Guid id)
        {
            return _mapper.Map<NotaDocumentosObterResponse>(_notaDocumentoService.ObterPorId(id));
        }

        public IEnumerable<NotaDocumentosObterResponse> ObterTodos()
        {
            return _mapper.Map<IEnumerable<NotaDocumentosObterResponse>>(_notaDocumentoService.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _notaDocumentoService.Remover(id);
            _unitOfWork.Commit();
        }
    }
}
