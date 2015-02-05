using System.Collections.Generic;
using System.Reflection;

namespace ConsoleDisplay.Core.Contracts
{
    public interface IMethodRepository
    {
        IList<MethodInfo> MethodInfos { get; }
        int Count { get; }
    }
}
