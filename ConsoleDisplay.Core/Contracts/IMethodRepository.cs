using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleDisplay.Core.Contracts
{
    public interface IMethodRepository
    {
        IList<MethodInfo> MethodInfos { get; }
    }
}
