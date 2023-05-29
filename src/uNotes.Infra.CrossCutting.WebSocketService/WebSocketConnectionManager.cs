using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace uNotes.Infra.CrossCutting.WebSocketService
{
    public class WebSocketConnectionManager
    {
        private readonly ConcurrentDictionary<string, WebSocket> _sockets = new();

        public void AddSocket(WebSocket socket)
        {
            string socketId = Guid.NewGuid().ToString();
            _sockets.TryAdd(socketId, socket);
        }

        public async Task RemoveSocketAsync(string socketId)
        {
            if (_sockets.TryRemove(socketId, out WebSocket socket))
            {
                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Socket connection closed", CancellationToken.None);
            }
        }

        public WebSocket GetSocketById(string socketId)
        {
            _sockets.TryGetValue(socketId, out WebSocket socket);
            return socket;
        }

        public Dictionary<string, WebSocket> GetAll()
        {
            return _sockets.ToDictionary(p => p.Key, p => p.Value);
        }
    }

}
