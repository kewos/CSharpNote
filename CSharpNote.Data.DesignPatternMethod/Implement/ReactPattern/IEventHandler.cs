using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPattern.Implement.ReactPattern
{
    public interface IEventHandler
    {
        void HandleEvent(byte[] data);
        TcpListener GetHandler();
    }
}
