using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.Implement.CQRSPattern
{
    public interface IEventBus
    {
        void Send<TEvent>(TEvent command)
            where TEvent : IEvent;

    }

    public class EventBus : IEventBus
    {
        public void Send<TEvent>(TEvent command) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }
    }
}
