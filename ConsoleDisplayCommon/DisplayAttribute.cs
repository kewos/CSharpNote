using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace ConsoleDisplayCommon
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class DisplayMethodAttribute : Attribute 
    {
        private string reference;
        private string comment;
        private string date;
        private bool display;

        public DisplayMethodAttribute() { }
        private DisplayMethodAttribute(bool display)
        {
            this.display = display;
        }

        public DisplayMethodAttribute(string reference, bool display = false)
            : this(display)
        {
            this.reference = reference;
        }

        public DisplayMethodAttribute(string reference, string date, bool display = false)
            : this(reference, display)
        {
            this.date = date;
        }

        public DisplayMethodAttribute(string reference, string date, string comment, bool display = false)
            : this(reference, date, display)
        {
            this.comment = comment;
        }

        public string Reference { get { return reference; } }
        public string Comment { get { return comment; } }
        public string Date { get { return date; } }
        public bool Display { get { return display; } }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class DisplayClassAttribue : ContextAttribute, IContributeObjectSink
    {
        public DisplayClassAttribue(): base("DisplayClassAttribue") {}

        public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink next)
        {
            return new ExtraMsgHandler(next);
        }
    }

    public sealed class ExtraMsgHandler : IMessageSink
    {
        private IMessageSink nextSink;
        public IMessageSink NextSink{ get { return nextSink; } }

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
