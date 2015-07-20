using System;
using System.Diagnostics;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using CSharpNote.Common.Utility;

namespace CSharpNote.Common.Attributes
{
    /// <summary>
    /// 實作Aop
    /// </summary>
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
        private readonly IMessageSink nextSink;

        public ExtraMsgHandler(IMessageSink nextSink)
        {
            this.nextSink = nextSink;
        }

        public IMessageSink NextSink { get { return nextSink; } }

        #region IMessageSinkMethod
        public IMessage SyncProcessMessage(IMessage msg)
        {
            var methodCallMsg = msg as IMethodCallMessage;
            var info = Attribute.GetCustomAttribute(methodCallMsg.MethodBase, typeof(MarkedItemAttribute)) as MarkedItemAttribute;

            if (info == null)
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
                var resultMsg = nextSink.SyncProcessMessage(msg);
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
