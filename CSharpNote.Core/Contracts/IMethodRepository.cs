using System.Collections.Generic;
using System.Reflection;

namespace CSharpNote.Core.Contracts
{
    public interface IMethodRepository
    {
        /// <summary>
        /// Method數量
        /// </summary>
        int Count { get; }

        /// <summary>
        /// RepositoryName
        /// </summary>
        string RepositoryName { get; }

        /// <summary>
        /// indexer
        /// </summary>
        MethodInfo this[int index] { get; }

        /// <summary>
        /// 取得MethodInfoNames
        /// </summary>
        IEnumerable<string> GetMethodNames();
    }
}
