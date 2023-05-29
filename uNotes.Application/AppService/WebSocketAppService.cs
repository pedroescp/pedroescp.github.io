using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using uNotes.Application.AppService.Interface;
using uNotes.Application.WebSocketUpdates;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.AWS.Interfaces;
using uNotes.Infra.CrossCutting.Notificacoes;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Application.AppService
{
    public class WebSocketAppService : IWebSocketAppService
    {
        private readonly IDocumentoService _documentoService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();

        public WebSocketAppService(IDocumentoService documentoService,
                                 IUnitOfWork unitOfWork)
        {
            _documentoService = documentoService;
            _unitOfWork = unitOfWork;
        }

        public async Task AtualizarDocumento(string json)
        {
            var message = JsonConvert.DeserializeObject<DocumentoAtualizarMensagem>(json);
            _documentoService.Atualizar(new Documento
            {
                Id = message.DocumentoId,
                UsuarioAtualizacaoId = message.UsuarioId,
                Texto = message.Texto
            });
            _unitOfWork.Commit();
            await BroadcastDocumentUpdate(message);
        }

        private async Task BroadcastDocumentUpdate(DocumentoAtualizarMensagem message)
        {
            foreach (var socket in _sockets.Values)
            {
                await socket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message))), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
