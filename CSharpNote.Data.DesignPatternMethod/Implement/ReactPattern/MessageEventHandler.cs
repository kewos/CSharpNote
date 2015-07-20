using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.ReactPattern
{
    public class MessageEventHandler : IEventHandler
    {
        private readonly TcpListener _listener;

        public MessageEventHandler(IPAddress ipAddress, int port)
        {
            _listener = new TcpListener(ipAddress, port);
        }

        public void HandleEvent(byte[] data)
        {
            string message = Encoding.UTF8.GetString(data);
        }

        public TcpListener GetHandler()
        {
            return _listener;
        }
    }
}
