using System;
using System.Runtime.Remoting.Messaging;
using CSharpNote.Common.Utility;

namespace CSharpNote.Common.Attributes
{
    public sealed class TimeExecuteDecorator : IMessageSink
    {
        private readonly IMessageSink nextSink;

        #region Constructor

        public TimeExecuteDecorator(IMessageSink next)
        {
            nextSink = next;
        }

        #endregion

        #region Property

        public IMessageSink NextSink
        {
            get { return nextSink; }
        }

        #endregion

        #region Private method

        private IMessage CaculateExecuteTime(IMessage msg, MarkedItemAttribute info)
        {
            Console.Clear();
            using (new TimeMeasurer())
            {
                return NextSink.SyncProcessMessage(msg);
            }
        }

        #endregion

        #region Method

        public IMessage SyncProcessMessage(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var info =
                Attribute.GetCustomAttribute(methodCall.MethodBase, typeof (MarkedItemAttribute)) as MarkedItemAttribute;

            return (info == null)
                ? NextSink.SyncProcessMessage(msg)
                : CaculateExecuteTime(msg, info);
        }

        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return null;
        }

        #endregion
    }
}