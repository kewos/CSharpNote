﻿namespace CSharpNote.Data.DesignPattern.Implement.CQRSPattern
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