using System;
using System.Runtime.Remoting.Messaging;
using ConsoleDisplay.Common.Attributes;

namespace ConsoleDisplay.Common
{
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
            var info = Attribute.GetCustomAttribute(methodCallMsg.MethodBase, typeof(DisplayMethodAttribute)) as DisplayMethodAttribute;
            if (methodCallMsg == null || info == null) return nextSink.SyncProcessMessage(msg);
            return DisplayExtraMsg(msg, info);
        }

        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return null;
        }
        #endregion

        private IMessage DisplayExtraMsg(IMessage msg, DisplayMethodAttribute info)
        {
            Console.Clear();
            ShowMethodInfomation(info);
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            Console.WriteLine("==================start->>");
            IMessage resultMsg = nextSink.SyncProcessMessage(msg);
            sw.Stop();
            Console.WriteLine("==================stop->> excution time:{0}ms", sw.Elapsed.Milliseconds);
            return resultMsg;
        }

        private void ShowMethodInfomation(DisplayMethodAttribute info)
        {
            if (!info.Display) return;
            if (info.Reference != null) Console.WriteLine(info.Reference);
            if (info.Date != null) Console.WriteLine(info.Date);
            if (info.Comment != null) Console.WriteLine(info.Comment);
        }
    }
}
