using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using uNotes.Application.AppService.Interface;
using uNotes.Infra.CrossCutting.Notificacoes;
using WebSocketManager.Common;

namespace uNotes.Api.Controllers
{
    [ApiController]
    [Route("websocket")]
    [Authorize]
    public class WebSocketController : BaseController
    {
        private readonly ILogger<WebSocketController> _logger;
        private static ConcurrentDictionary<string, WebSocket> ConnectedSockets = new();
        public WebSocketController(INotificador notificador, ILogger<WebSocketController> logger, IWebSocketAppService webSocketAppService) : base(notificador, logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task Recebe()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                _logger.Log(LogLevel.Information, "WebSocket connection established");
                await Echo(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }
        }

        private async Task OnConnected(WebSocket webSocket, string socketId)
        {
            _logger.LogInformation($"WebSocket connected: {webSocket}");
            ConnectedSockets.TryAdd(socketId, webSocket);
            await Task.CompletedTask;
        }

        private async Task OnDisconnected(WebSocket webSocket, string socketId)
        {
            _logger.LogInformation($"WebSocket disconnected: {webSocket}");
            ConnectedSockets.TryRemove(socketId, out _);
            await Task.CompletedTask;
        }

        private async Task OnMessageReceived(string message)
        {
            _logger.LogInformation($"Message received: {message}");
            await Task.CompletedTask;
        }

        private async Task Echo(WebSocket webSocket)
        {
            try
            {
                string socketId = Guid.NewGuid().ToString();
                // Handle the WebSocket connection
                await OnConnected(webSocket, socketId);

                var buffer = new byte[1024 * 4];
                WebSocketReceiveResult result = null;

                while (webSocket.State == WebSocketState.Open)
                {
                    result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        var message = Encoding.UTF8.GetString(buffer, 0, result.Count);

                        await SendToAllConnectedClientsAsync(message);

                        await OnMessageReceived(message);
                    }
                    else if (result.MessageType == WebSocketMessageType.Binary)
                    {
                        // Handle binary data
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await OnDisconnected(webSocket, socketId);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
            finally
            {
                if (webSocket != null)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "WebSocket closed", CancellationToken.None);
                }
            }
        }

        private async Task SendToAllConnectedClientsAsync(string message)
        {
            foreach (var webSocket in ConnectedSockets.Values)
            {
                if (webSocket.State == WebSocketState.Open)
                {
                    var buffer = Encoding.UTF8.GetBytes(message);
                    await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }
    }
}
