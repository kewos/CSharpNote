using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ConsoleDisplay.Core.Contracts;
using ConsoleDisplay.Common;

namespace ConsoleDisplay.Core.Implements
{
    public abstract class AbstractMethodRepository : ContextBoundObject, IMethodRepository
    {
        public virtual List<MethodInfo> MethodInfos
        {
            get
            {
                return this.GetType()
                        .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        .Where(method => method.GetCustomAttribute(typeof(DisplayMethodAttribute), false) != null)
                        .OrderBy(method => method.Name)
                        .ToList();
            }
        }
    }
}
