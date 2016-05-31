using System;

namespace CSharpNote.Data.DesignPattern.Implement.CQRSPattern
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