using System.Net;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.ReactPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class ReactPatternImplement : AbstractExecuteModule
    {
        /// <summary>
        ///     Reference:http://www.robertsindall.co.uk/blog/the-reactor-pattern-using-c-sharp/
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            IEventHandler client1 = new MessageEventHandler(IPAddress.Parse("123.123.123.123"), 123);
            IEventHandler client2 = new MessageEventHandler(IPAddress.Parse("234.234.234.234"), 123);
            IEventHandler client3 = new MessageEventHandler(IPAddress.Parse("245.245.245.245"), 123);

            ISynchronousEventDemultiplexer synchronousEventDemultiplexer = new SynchronousEventDemultiplexer();

            var dispatcher = new Reactor(synchronousEventDemultiplexer);

            dispatcher.RegisterHandle(client1);
            dispatcher.RegisterHandle(client2);
            dispatcher.RegisterHandle(client3);

            dispatcher.HandleEvents();
        }
    }
}