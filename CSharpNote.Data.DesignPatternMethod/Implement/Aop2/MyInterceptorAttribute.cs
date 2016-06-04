using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace CSharpNote.Data.DesignPattern.Implement.Aop2
{
    [AttributeUsage(AttributeTargets.Class)]
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