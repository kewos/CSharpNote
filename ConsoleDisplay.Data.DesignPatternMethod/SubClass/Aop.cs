using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.Reflection;

namespace ConsoleDisplay.Data.DesignPatternMethod.SubClass
{
    interface IActor
    {
        string Name { get; set; }
    }

    public class Actor : IActor
    {
        public string Name{ get; set; }
        public Actor(string name)
        {
            this.Name = name;
        }
    }

    interface IConcern<T>
    {
        T This { get;}
    }

    public class Concern : IConcern<Actor>
    {
        public Actor This{ get; set; }

        public Concern(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "Null String";
            }

            This = new Actor(name);
        }
    }

    public class JoinPoint : IEquatable<JoinPoint>
    {
        public MethodBase pointcutMethod;
        public MethodBase concernMethod;

        private JoinPoint(MethodBase pointcutMethod, MethodBase concernMethod)
        {
            this.pointcutMethod = pointcutMethod;
            this.concernMethod = concernMethod;
        }

        public static JoinPoint Create(MethodBase pointcutMethod, MethodBase concernMethod)
        {
            return new JoinPoint(pointcutMethod, concernMethod);
        }

        #region Equatable
        public bool Equals(JoinPoint other)
        {
            return this.pointcutMethod == other.concernMethod && this.concernMethod == other.concernMethod;
        }

        public static bool operator ==(JoinPoint x, JoinPoint y) 
        {
            return x.Equals(y); 
        }

        public static bool operator !=(JoinPoint x, JoinPoint y)
        {
            return !(x == y);
        }

        public override bool Equals(object other)
        {
            if (other is JoinPoint) return Equals((JoinPoint)other);
            return false;
        }

        public override int GetHashCode()
        {
            return this.pointcutMethod.GetHashCode() ^ this.concernMethod.GetHashCode();
        }

        #endregion
    }

    public class AOP : List<JoinPoint>
    {
        static readonly AOP _registry;
        static AOP() { _registry = new AOP(); }
        private AOP() { }
        public static AOP Registry { get { return _registry; } }

        public void Join(MethodBase pointcutMethod, MethodBase concernMethod)
        {
            var joinPoint = JoinPoint.Create(pointcutMethod, concernMethod);
            if (!this.Contains(joinPoint)) this.Add(joinPoint);
        }

        public static class Factory
        {
            public static object Create<T>(params object[] constructorArgs)
            {
                var joinPoints = AOP.Registry.Where(joinPoint => joinPoint.pointcutMethod.DeclaringType == typeof(T)).ToList();
                var paremeterType = constructorArgs.Select(x => x.GetType()).ToArray();
                var concernConstructors = joinPoints
                                            .Where(x =>
                                                x.pointcutMethod.IsConstructor
                                                && Utils.TypeArrayMatch(paremeterType, x.pointcutMethod.GetParameters().Select(a => a.ParameterType).ToArray()))
                                            .Select(x => x.concernMethod)
                                            .ToList();

                var concernType = concernConstructors.First().DeclaringType;
                var concernObj = Activator.CreateInstance(concernType, constructorArgs);

                //回傳代理
                return new Interceptor(concernObj, concernConstructors.ToArray<object>(), joinPoints.ToArray()).GetTransparentProxy();
            }
        }
    }

    public static class Utils
    {
        public static Func<Type[], Type[], bool> TypeArrayMatch = (x, y) =>
        {
            for (int i = 0; i < x.Length; ++i)
            {
                if (x[i] != y[i]) return false;
            }
            return true;
        };

    }

    public sealed class Interceptor : RealProxy, System.Runtime.Remoting.IRemotingTypeInfo
    {
        object Target { get; set; }
        object[] Concerns { get; set; }
        JoinPoint[] Joinpoints { get; set; }

        internal Interceptor(object target, object[] concerns, JoinPoint[] joinpoints)
            : base(typeof(MarshalByRefObject))
        {
            Target = target;
            Concerns = concerns;
            Joinpoints = joinpoints;
        }

        public string TypeName { get; set; }

        public bool CanCastTo(Type fromType, object o) { return true; }

        //有使用任何方法都會呼叫invoke
        public override System.Runtime.Remoting.Messaging.IMessage Invoke(System.Runtime.Remoting.Messaging.IMessage msg)
        {
            object returnValue = null;
            IMethodCallMessage methodMessage = (IMethodCallMessage)msg;
            MethodBase method = methodMessage.MethodBase;

            var concernMethod = Joinpoints
                .Where(
                    x =>
                        x.pointcutMethod.Name == method.Name
                        && Utils.TypeArrayMatch(x.pointcutMethod.GetParameters().Select(p => p.ParameterType).ToArray(), method.GetParameters().Select(p => p.ParameterType).ToArray())
                    )
                    .Select(x => x.concernMethod).FirstOrDefault();

            if (concernMethod != null)
            {
                var param = concernMethod.IsStatic ? null : Concerns.First(x => x.GetType() == concernMethod.DeclaringType);
                returnValue = concernMethod.Invoke(param, methodMessage.Args);
            }

            return new ReturnMessage(returnValue, methodMessage.Args, methodMessage.ArgCount, methodMessage.LogicalCallContext, methodMessage);
        }
    }
}
