using System;
using System.Runtime.Remoting.Messaging;

namespace CSharpNote.Data.DesignPattern.Implement.Aop2
{
    public sealed class MyAopHandler : IMessageSink
    {
        public MyAopHandler(IMessageSink nextSink)
        {
            NextSink = nextSink;
        }

        public IMessageSink NextSink { get; private set; }

        public IMessage SyncProcessMessage(IMessage msg)
        {
            IMessage retMsg = null;

            var call = msg as IMethodCallMessage;

            if (call == null ||
                (Attribute.GetCustomAttribute(call.MethodBase, typeof (MyInterceptorMethodAttribute))) == null)
            {
                retMsg = NextSink.SyncProcessMessage(msg);
            }
            else
            {
                Console.WriteLine("==============");
                retMsg = NextSink.SyncProcessMessage(msg);
                Console.WriteLine("==============");
            }

            return retMsg;
        }

        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return null;
        }
    }
}