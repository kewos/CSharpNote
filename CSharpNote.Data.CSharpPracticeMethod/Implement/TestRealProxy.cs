using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class TestRealProxy : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            var baby = LoggingProxy.Wrap(new Baby());
            Console.WriteLine("Name = {0}", baby.Name);

            try
            {
                baby.Sleep();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception = {0}", e.Message);
            }
        }
    }

    internal class Baby : MarshalByRefObject
    {
        public string Name
        {
            get { return "Annabelle"; }
        }

        public void Sleep()
        {
            throw new InvalidOperationException("Teething in progress");
        }
    }

    internal class LoggingProxy : RealProxy
    {
        private readonly object target;

        private LoggingProxy(object target)
            : base(target.GetType())
        {
            this.target = target;
        }

        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;

            if (methodCall != null)
            {
                return HandleMethodCall(methodCall);
            }

            return null;
        }

        private IMessage HandleMethodCall(IMethodCallMessage methodCall)
        {
            Console.WriteLine("Calling method {0}...", methodCall.MethodName);

            try
            {
                var result = methodCall.MethodBase.Invoke(target, methodCall.InArgs);
                Console.WriteLine("Calling {0}... OK", methodCall.MethodName);
                return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
            }
            catch (TargetInvocationException invocationException)
            {
                var exception = invocationException.InnerException;
                Console.WriteLine("Calling {0}... {1}", methodCall.MethodName, exception.GetType());
                return new ReturnMessage(exception, methodCall);
            }
        }

        public static T Wrap<T>(T target)
            where T : MarshalByRefObject
        {
            return (T)new LoggingProxy(target).GetTransparentProxy();
        }
    }
}