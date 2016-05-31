using System.Net.Sockets;

namespace CSharpNote.Data.DesignPattern.Implement.ReactPattern
{
    public interface IEventHandler
    {
        void HandleEvent(byte[] data);
        TcpListener GetHandler();
    }
}