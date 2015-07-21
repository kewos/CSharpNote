using System.Collections.Generic;
using System;
using System.Linq;
using CSharpNote.Common.Extensions;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.DependecyContainer
{
    /// <summary>
    /// DependecyConainer內部實體的生命週期
    /// </summary>
    public enum LifeCycle
    {
        //一般
        Transient,
        //單例
        Singleton
    }

    public class DependecyConainer
    {
        /// <summary>
        /// DependecyConainer的實體
        /// </summary>
        private static DependecyConainer instance;

        /// <summary>
        /// 容器保存Func達到LazyExcution
        /// </summary>
        private readonly Dictionary<Type, Func<object>> container;

        /// <summary>
        /// 容器保存Singleton物件
        /// </summary>
        private readonly Dictionary<Type, object> singltonContainer;

        /// <summary>
        /// Singleton物件的鎖
        /// </summary>
        private readonly static object lockObject = new object();

        /// <summary>
        /// Constructor
        /// </summary>
        private DependecyConainer()
        {
            singltonContainer = new Dictionary<Type, object>();
            container = new Dictionary<Type, Func<object>>();
        }

        public static DependecyConainer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DependecyConainer();
                }

                return Instance;
            }
        }

        /// <summary>
        /// 註冊可選LifeCycle
        /// </summary>
        public void RegistType<TInterface, TType>(LifeCycle lifeCycle = LifeCycle.Transient) 
            where TType : class, TInterface
        {
            switch (lifeCycle)
            {
                case LifeCycle.Transient:
                    Regist<TInterface, TType>();
                    break;
                case LifeCycle.Singleton:
                    RegistSingleton<TInterface, TType>();
                    break;
            }
        }

        /// <summary>
        /// 註冊LifeCycle.Singleton
        /// </summary>
        public void RegistSingleton<TInterface, TType>() 
            where TType : class, TInterface
        {
            var @interface = typeof(TInterface);
            var @type = typeof (TType);

            if (container.ContainsKey(@interface))
            {
                throw new ArgumentException("ContainInstance");
            }

            container.Add(@interface, () =>
            {
                if (!singltonContainer.ContainsKey(@interface))
                {
                    lock (lockObject)
                    {
                        singltonContainer.Add(typeof (TInterface),
                            Activator.CreateInstance(@type, GetMatchParameterArray(@type)));
                    }
                }

                return singltonContainer[@interface];
            });
        }

        /// <summary>
        /// 註冊LifeCycle.Transient
        /// </summary>
        public void Regist<TInterface, TType>()
            where TType : class, TInterface
        {
            var @type = typeof (TType);
            var @interface = typeof(TInterface);

            container.Add(@interface, 
                () => Activator.CreateInstance(@type, GetMatchParameterArray(@type)));
        }

        /// <summary>
        /// 取得Instance
        /// </summary>
        public TInterface Resolve<TInterface>()
        {
            Func<object> createInstanceFunc;

            if (!container.TryGetValue(typeof(TInterface), out createInstanceFunc))
            {
                throw new ArgumentException("CantFindInstance");
            }

            return createInstanceFunc() as dynamic;
        }

        #region private method
        /// <summary>
        /// 透過Type取得有被存於Container
        /// </summary>
        private object[] GetMatchParameterArray(Type type)
        {
            return type.GetMatchConstructor().GetParameters()
                .Select(p => container[p.ParameterType]())
                .ToArray();
        }
        #endregion
    }
}