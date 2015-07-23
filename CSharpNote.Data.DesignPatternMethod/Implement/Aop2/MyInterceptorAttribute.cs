using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace CSharpNote.Data.DesignPatternMethod.Implement
{
    

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class MyInterceptorAttribute : ContextAttribute, IContributeObjectSink
    {
        public MyInterceptorAttribute()
            : base("MyInterceptor")
        {
        }

        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
        {
            return new MyAopHandler(next);
        }
    }
}