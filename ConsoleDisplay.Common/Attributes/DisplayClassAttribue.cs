using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace ConsoleDisplay.Common
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
