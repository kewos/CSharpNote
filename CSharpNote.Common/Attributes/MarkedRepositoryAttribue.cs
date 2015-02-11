using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using CSharpNote.Common.Aops;

namespace CSharpNote.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class MarkedRepositoryAttribue : ContextAttribute, IContributeObjectSink
    {
        public MarkedRepositoryAttribue() : base("MarkedRepositoryAttribue") { }

        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
        {
            return new ExtraMsgHandler(next);
        }
    }
}
