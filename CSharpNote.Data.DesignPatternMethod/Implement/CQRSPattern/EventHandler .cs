using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.Implement.CQRSPattern
{
    public interface IEventHandler<TEvent>
        where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }

    //public class EventHandler : IEventHandler<Event>
    //{
    //    private readonly CheckCommandService commandService;

    //    public void Handle(IEvent @event)
    //    {
            
    //    }
    //}
}
