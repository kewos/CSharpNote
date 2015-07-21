using System;

namespace CSharpNote.Data.DesignPatternMethod.Implement.ObserverPattern
{
    public class SmartPhoneObserver : ObserverBase<Rss>, ISmartPhoneObserver
    {
        public override void OnNext(Rss value)
        {
            Console.WriteLine("{0}:Get Message {1}", GetType().Name, value.Message);
        }
    }
}