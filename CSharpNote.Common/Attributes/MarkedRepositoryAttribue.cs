using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using CSharpNote.Common.Utility;

namespace CSharpNote.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class MarkedRepositoryAttribue : ContextAttribute, IContributeObjectSink
    {
        public MarkedRepositoryAttribue() : base("MarkedRepositoryAttribue")
        {
        }

        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
        {
            return new ExtraMsgHandler(next);
        }
    }

    public sealed class ExtraMsgHandler : IMessageSink
    {
        private IMessageSink nextSink;
        public IMessageSink NextSink { get { return nextSink; } }

        public ExtraMsgHandler(IMessageSink nextSink)
        {
            this.nextSink = nextSink;
        }

        #region IMessageSinkMethod
        public IMessage SyncProcessMessage(IMessage msg)
        {
            IMethodCallMessage methodCallMsg = msg as IMethodCallMessage;
            var info = Attribute.GetCustomAttribute(methodCallMsg.MethodBase, typeof(MarkedItemAttribute)) as MarkedItemAttribute;

            if (methodCallMsg == null || info == null)
            {
                return nextSink.SyncProcessMessage(msg);
            }
            
            return DisplayExtraMsg(msg, info);
        }

        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return null;
        }
        #endregion

        #region private method
        private IMessage DisplayExtraMsg(IMessage msg, MarkedItemAttribute info)
        {
            Console.Clear();
            ShowMethodInfomation(info);
            using (new TimeMeasurer())
            {
                IMessage resultMsg = nextSink.SyncProcessMessage(msg);
                return resultMsg;
            }
        }

        private void ShowMethodInfomation(MarkedItemAttribute info)
        {
            if (!info.Display)
            {
                return;
            }
            if (info.Reference != null)
            {
                Console.WriteLine(info.Reference);
            }
            if (info.Date != null)
            {
                Console.WriteLine(info.Date);
            }
            if (info.Comment != null)
            {
                Console.WriteLine(info.Comment);
            }
        }
        #endregion
    }
}
