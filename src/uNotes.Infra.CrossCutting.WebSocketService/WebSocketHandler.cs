using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace uNotes.Infra.CrossCutting.WebSocketService;
public class WebSocketHandler
{
    private readonly ConcurrentDictionary<string, WebSocket> _sockets = new();
    protected WebSocketHandler()
    {
    }

    protected ILogger<WebSocketHandler> Logger { get; }

    public virtual async Task OnConnected(WebSocket socket)
    {
        Logger.LogInformation($"WebSocket connected: {socket}");
        await Task.CompletedTask;
    }

    public virtual async Task OnDisconnected(WebSocket socket)
    {
        Logger.LogInformation($"WebSocket disconnected: {socket}");
        await Task.CompletedTask;
    }

    public virtual async Task OnMessageReceived(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
    {
        await Task.CompletedTask;
    }
    public static async Task HandleWebSocket(WebSocket webSocket)
    {

        var buffer = new byte[1024 * 4];
        WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

        while (!result.CloseStatus.HasValue)
        {
            string message = Encoding.UTF8.GetString(buffer, 0, result.Count);

            await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);

            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        }

        await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
    }
}
