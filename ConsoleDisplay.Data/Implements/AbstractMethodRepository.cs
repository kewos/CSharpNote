using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ConsoleDisplay.Data.Contracts;
using ConsoleDisplay.Common;

namespace ConsoleDisplay.Data.Implements
{
    public abstract class AbstractMethodRepository : ContextBoundObject, IMethodRepository
    {
        public virtual List<MethodInfo> MethodInfos
        {
            get
            {
                return this.GetType()
                        .GetMethods()
                        .Where(method => method.GetCustomAttribute(typeof(DisplayMethodAttribute), false) != null)
                        .OrderBy(method => method.Name)
                        .ToList();
            }
        }
    }
}
