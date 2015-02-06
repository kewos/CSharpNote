using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpNote.Core.Contracts;
using CSharpNote.Common.Attributes;

namespace CSharpNote.Core.Implements
{
    public abstract class AbstractMethodRepository : ContextBoundObject, IMethodRepository
    {
        private IList<MethodInfo> methodInfos;

        public int Count
        {
            get
            {
                return methodInfos.Count;
            }
        }

        public virtual IList<MethodInfo> MethodInfos
        {
            get
            {
                if (methodInfos == null)
                {
                    methodInfos = GetType()
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
