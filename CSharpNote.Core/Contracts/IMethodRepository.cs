using System.Collections.Generic;
using System.Reflection;

namespace CSharpNote.Core.Contracts
{
    public interface IMethodRepository
    {
        IList<MethodInfo> MethodInfos { get; }
        int Count { get; }
    }
}
