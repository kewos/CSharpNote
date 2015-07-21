using System.Net;
using System.Net.Sockets;
using System.Text;


namespace CSharpNote.Data.DesignPatternMethod.Implement.ReactPattern
{
    public class MessageEventHandler : IEventHandler
    {
        private readonly TcpListener listener;

        public MessageEventHandler(IPAddress ipAddress, int port)
        {
            listener = new TcpListener(ipAddress, port);
        }

        public void HandleEvent(byte[] data)
        {
            var message = Encoding.UTF8.GetString(data);
        }

        public TcpListener GetHandler()
        {
            return listener;
        }
    }
}
