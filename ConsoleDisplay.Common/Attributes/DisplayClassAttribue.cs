using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using ConsoleDisplay.Common.Aops;

namespace ConsoleDisplay.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class DisplayClassAttribue : ContextAttribute, IContributeObjectSink
    {
        public DisplayClassAttribue() : base("DisplayClassAttribue") { }

        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
        {
            return new ExtraMsgHandler(next);
        }
    }
}
