using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.WebSockets;

namespace uNotes.Infra.CrossCutting.WebSocket
{
    public interface IWebSocketService
    {
        Task Echo(WebSocket. webSocket);
    }
}
