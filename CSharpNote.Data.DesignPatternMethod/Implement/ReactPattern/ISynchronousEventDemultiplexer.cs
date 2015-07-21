using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.Implement.ReactPattern
{
    public interface ISynchronousEventDemultiplexer
    {
        IList<TcpListener> Select(ICollection<TcpListener> listeners);
    }
}
