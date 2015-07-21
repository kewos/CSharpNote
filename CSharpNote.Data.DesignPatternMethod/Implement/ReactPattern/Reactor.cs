using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.Implement.ReactPattern
{
    public class Reactor : IReactor
    {
        private readonly ISynchronousEventDemultiplexer _synchronousEventDemultiplexer;
        private readonly IDictionary<TcpListener, IEventHandler> _handlers;

        public Reactor(ISynchronousEventDemultiplexer synchronousEventDemultiplexer)
        {
            _synchronousEventDemultiplexer = synchronousEventDemultiplexer;
            _handlers = new Dictionary<TcpListener, IEventHandler>();
        }

        public void RegisterHandle(IEventHandler eventHandler)
        {
            _handlers.Add(eventHandler.GetHandler(), eventHandler);
        }

        public void RemoveHandle(IEventHandler eventHandler)
        {
            _handlers.Remove(eventHandler.GetHandler());
        }

        public void HandleEvents()
        {
            while (true)
            {
                IList<TcpListener> listeners = _synchronousEventDemultiplexer.Select(_handlers.Keys);

                foreach (TcpListener listener in listeners)
                {
                    int dataReceived = 0;
                    byte[] buffer = new byte[1];
                    IList<byte> data = new List<byte>();

                    Socket socket = listener.AcceptSocket();

                    do
                    {
                        dataReceived = socket.Receive(buffer);

                        if (dataReceived > 0)
                        {
                            data.Add(buffer[0]);
                        }

                    } while (dataReceived > 0);

                    socket.Close();

                    _handlers[listener].HandleEvent(data.ToArray());
                }
            }
        }
    }
}
