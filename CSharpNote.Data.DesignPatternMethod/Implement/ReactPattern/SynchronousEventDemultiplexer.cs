﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace CSharpNote.Data.DesignPattern.Implement.ReactPattern
{
    public class SynchronousEventDemultiplexer : ISynchronousEventDemultiplexer
    {
        public IList<TcpListener> Select(ICollection<TcpListener> listeners)
        {
            var tcpListeners =
                new List<TcpListener>(from listener in listeners
                    where listener.Pending()
                    select listener);
            return tcpListeners;
        }
    }
}