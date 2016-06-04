using System;
using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.ObserverPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class ObserverPatternImplement : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var website = new WebSiteObservable();
            var clients = new List<IObserver<Rss>> {new PcObserver(), new SmartPhoneObserver()};
            clients.ForEach(client =>
            {
                using (website.Subscribe(client))
                {
                    website.Notify(new Rss {Message = "Hello"});
                }
            });
        }
    }
}