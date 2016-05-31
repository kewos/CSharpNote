using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace CSharpNote.Data.DesignPattern.Implement.ReactPattern
{
    public class Reactor : IReactor
    {
        private readonly IDictionary<TcpListener, IEventHandler> handlers;
        private readonly ISynchronousEventDemultiplexer synchronousEventDemultiplexer;

        public Reactor(ISynchronousEventDemultiplexer synchronousEventDemultiplexer)
        {
            this.synchronousEventDemultiplexer = synchronousEventDemultiplexer;
            handlers = new Dictionary<TcpListener, IEventHandler>();
        }

        public void RegisterHandle(IEventHandler eventHandler)
        {
            handlers.Add(eventHandler.GetHandler(), eventHandler);
        }

        public void RemoveHandle(IEventHandler eventHandler)
        {
            handlers.Remove(eventHandler.GetHandler());
        }

        public void HandleEvents()
        {
            while (true)
            {
                var listeners = synchronousEventDemultiplexer.Select(handlers.Keys);

                foreach (var listener in listeners)
                {
                    var dataReceived = 0;
                    var buffer = new byte[1];
                    IList<byte> data = new List<byte>();

                    var socket = listener.AcceptSocket();

                    do
                    {
                        dataReceived = socket.Receive(buffer);

                        if (dataReceived > 0)
                        {
                            data.Add(buffer[0]);
                        }
                    } while (dataReceived > 0);

                    socket.Close();

                    handlers[listener].HandleEvent(data.ToArray());
                }
            }
        }
    }
}