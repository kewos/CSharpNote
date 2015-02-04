using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ConsoleDisplay.Core.Contracts;
using ConsoleDisplay.Common.Attributes;

namespace ConsoleDisplay.Core.Implements
{
    public abstract class AbstractMethodRepository : ContextBoundObject, IMethodRepository
    {
        private IList<MethodInfo> methodInfos;

        public virtual IList<MethodInfo> MethodInfos
        {
            get
            {
                if (methodInfos == null)
                {
                    methodInfos = this.GetType()
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .Where(method => method.GetCustomAttribute(typeof(DisplayMethodAttribute), false) != null)
                        .OrderBy(method => method.Name)
                        .ToList();
                }

                return methodInfos;
            }
        }
    }
}
