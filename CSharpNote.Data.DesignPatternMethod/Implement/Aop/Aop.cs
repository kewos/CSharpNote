using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSharpNote.Data.DesignPattern.Implement.Aop
{
    public class AOP : List<JoinPoint>
    {
        private static readonly AOP registry;

        static AOP()
        {
            registry = new AOP();
        }

        private AOP()
        {
        }

        public static AOP Registry
        {
            get { return registry; }
        }

        public void Join(MethodBase pointcutMethod, MethodBase concernMethod)
        {
            var joinPoint = JoinPoint.Create(pointcutMethod, concernMethod);
            if (!Contains(joinPoint)) Add(joinPoint);
        }

        public static class Factory
        {
            public static object Create<T>(params object[] constructorArgs)
            {
                var joinPoints =
                    Registry.Where(joinPoint => joinPoint.pointcutMethod.DeclaringType == typeof (T)).ToList();
                var paremeterType = constructorArgs.Select(x => x.GetType()).ToArray();
                var concernConstructors = joinPoints
                    .Where(x =>
                        x.pointcutMethod.IsConstructor
                        &&
                        Utils.typeArrayMatch(paremeterType,
                            x.pointcutMethod.GetParameters().Select(a => a.ParameterType).ToArray()))
                    .Select(x => x.concernMethod)
                    .ToList();

                var concernType = concernConstructors.First().DeclaringType;
                var concernObj = Activator.CreateInstance(concernType, constructorArgs);

                //回傳代理
                return
                    new Interceptor(concernObj, concernConstructors.ToArray<object>(), joinPoints.ToArray())
                        .GetTransparentProxy();
            }
        }
    }
}