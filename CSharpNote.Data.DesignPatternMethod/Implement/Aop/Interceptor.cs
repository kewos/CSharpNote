using System;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace CSharpNote.Data.DesignPattern.Implement.Aop
{
    public sealed class Interceptor : RealProxy, IRemotingTypeInfo
    {
        internal Interceptor(object target, object[] concerns, JoinPoint[] joinpoints)
            : base(typeof (MarshalByRefObject))
        {
            Target = target;
            Concerns = concerns;
            Joinpoints = joinpoints;
        }

        private object Target { get; set; }
        private object[] Concerns { get; set; }
        private JoinPoint[] Joinpoints { get; set; }
        public string TypeName { get; set; }

        public bool CanCastTo(Type fromType, object o)
        {
            return true;
        }

        //有使用任何方法都會呼叫invoke
        public override IMessage Invoke(IMessage msg)
        {
            object returnValue = null;
            var methodMessage = (IMethodCallMessage) msg;
            var method = methodMessage.MethodBase;

            var concernMethod = Joinpoints
                .Where(
                    x =>
                        x.pointcutMethod.Name == method.Name
                        &&
                        Utils.typeArrayMatch(x.pointcutMethod.GetParameters().Select(p => p.ParameterType).ToArray(),
                            method.GetParameters().Select(p => p.ParameterType).ToArray())
                )
                .Select(x => x.concernMethod).FirstOrDefault();

            if (concernMethod != null)
            {
                var param = concernMethod.IsStatic
                    ? null
                    : Concerns.First(x => x.GetType() == concernMethod.DeclaringType);
                returnValue = concernMethod.Invoke(param, methodMessage.Args);
            }

            return new ReturnMessage(returnValue, methodMessage.Args, methodMessage.ArgCount,
                methodMessage.LogicalCallContext, methodMessage);
        }
    }
}