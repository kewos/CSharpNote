using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplay.Data.CSharpPracticeMethod.SubClass
{
    class Baby : MarshalByRefObject
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

    class LoggingProxy : System.Runtime.Remoting.Proxies.RealProxy
    {
        readonly object target;

        LoggingProxy(object target)
            : base(target.GetType())
        {
            this.target = target;
        }

        public override System.Runtime.Remoting.Messaging.IMessage Invoke(System.Runtime.Remoting.Messaging.IMessage msg)
        {
            var methodCall = msg as System.Runtime.Remoting.Messaging.IMethodCallMessage;

            if (methodCall != null)
            {
                return HandleMethodCall(methodCall); // <- see further
            }

            return null;
        }

        System.Runtime.Remoting.Messaging.IMessage HandleMethodCall(System.Runtime.Remoting.Messaging.IMethodCallMessage methodCall)
        {
            Console.WriteLine("Calling method {0}...", methodCall.MethodName);

            try
            {
                var result = methodCall.MethodBase.Invoke(target, methodCall.InArgs);
                Console.WriteLine("Calling {0}... OK", methodCall.MethodName);
                return new System.Runtime.Remoting.Messaging.ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
            }
            catch (System.Reflection.TargetInvocationException invocationException)
            {
                var exception = invocationException.InnerException;
                Console.WriteLine("Calling {0}... {1}", methodCall.MethodName, exception.GetType());
                return new System.Runtime.Remoting.Messaging.ReturnMessage(exception, methodCall);
            }
        }

        public static T Wrap<T>(T target)
            where T : MarshalByRefObject
        {
            return (T)new LoggingProxy(target).GetTransparentProxy();
        }
    }
}
