﻿using System;
using System.Runtime.Remoting.Messaging;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public sealed class MyAopHandler : IMessageSink
    {
        private IMessageSink nextSink;
        public IMessageSink NextSink
        {
            get { return nextSink; }
        }
        public MyAopHandler(IMessageSink nextSink)
        {
            this.nextSink = nextSink;
        }

        public IMessage SyncProcessMessage(IMessage msg)
        {
            IMessage retMsg = null;

            IMethodCallMessage call = msg as IMethodCallMessage;

            if (call == null || (Attribute.GetCustomAttribute(call.MethodBase, typeof(MyInterceptorMethodAttribute))) == null)
            {
                retMsg = nextSink.SyncProcessMessage(msg);
            }
            else
            {
                Console.WriteLine("==============");
                retMsg = nextSink.SyncProcessMessage(msg);
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