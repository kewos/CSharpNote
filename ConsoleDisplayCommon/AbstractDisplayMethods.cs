using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleDisplayCommon
{
    public abstract class AbstractDisplayMethods : ContextBoundObject
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
