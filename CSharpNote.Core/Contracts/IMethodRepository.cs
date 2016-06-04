using System.Collections.Generic;
using CSharpNote.Core.Implements;

namespace CSharpNote.Core.Contracts
{
    public interface IMethodRepository
    {
        /// <summary>
        ///     Method數量
        /// </summary>
        int Count { get; }

        /// <summary>
        ///     RepositoryName
        /// </summary>
        string RepositoryName { get; }

        /// <summary>
        ///     indexer
        /// </summary>
        AbstractExecuteModule this[int index] { get; }

        /// <summary>
        ///     取得MethodInfoNames
        /// </summary>
        IEnumerable<string> GetMethodNames();
    }
}