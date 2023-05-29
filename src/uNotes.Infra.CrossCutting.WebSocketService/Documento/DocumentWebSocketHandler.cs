using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using uNotes.Application.WebSocketUpdates;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Infra.CrossCutting.WebSocketService.Documento
{
    public class DocumentWebSocketHandler : WebSocketHandler
    {
        private readonly IDocumentoService _documentoService;
        private readonly IUnitOfWork _unitOfWork;
        private HttpContext _context;
        private readonly ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();

        public DocumentWebSocketHandler(IDocumentoService documentoService, IUnitOfWork unitOfWork, HttpContext context)
        {
            _documentoService = documentoService;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);
            _sockets.TryAdd(_context.Connection.Id, socket);
        }

        public override async Task OnDisconnected(WebSocket socket)
        {
            await base.OnDisconnected(socket);
            _sockets.TryRemove(_context.Connection.Id, out _);
        }

        public async Task OnMessageReceived(string json)
        {
            var message = JsonConvert.DeserializeObject<DocumentoAtualizarMensagem>(json);
            _documentoService.Atualizar(new Domain.Entidades.Documento {
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

        public async Task HandleDocumentoWebSocket(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
            }

            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
    }
}
