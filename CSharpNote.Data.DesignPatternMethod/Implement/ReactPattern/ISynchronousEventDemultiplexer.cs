using System.Collections.Generic;
using System.Net.Sockets;

namespace CSharpNote.Data.DesignPattern.Implement.ReactPattern
{
    public interface ISynchronousEventDemultiplexer
    {
        IList<TcpListener> Select(ICollection<TcpListener> listeners);
    }
}