using System.Runtime.Remoting.Messaging;

namespace CSharpNote.Common.Attributes
{
    public sealed class RequiredDecorator : IMessageSink
    {
        private readonly IMessageSink nextSink;

        public RequiredDecorator(IMessageSink next)
        {
            nextSink = next;
        }

        #region Property

        public IMessageSink NextSink
        {
            get { return nextSink; }
        }

        #endregion

        #region Method

        public IMessage SyncProcessMessage(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            return NextSink.SyncProcessMessage(msg);
        }

        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return null;
        }

        #endregion
    }
}