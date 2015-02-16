using System.Collections.Generic;

namespace CSharpNote.Core.Contracts
{
    public interface ICSharperNoteService
    {
        /// <summary>
        /// Repository數量
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 取得RepositoryNames
        /// </summary>
        IEnumerable<string> GetRepositoryNames();

        /// <summary>
        /// 取得Repository 透過 Index
        /// </summary>
        IMethodRepository this[int index] { get; }
    }
}
