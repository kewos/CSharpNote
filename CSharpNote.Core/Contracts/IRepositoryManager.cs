using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Core.Contracts
{
    public interface IRepositoryManager
    {
        /// <summary>
        /// 取得RepositoryNames
        /// </summary>
        IEnumerable<string> GetRepositoryNames();

        /// <summary>
        /// 取得Repository 透過 Index
        /// </summary>
        IMethodRepository GetRepositoryByIndex(int index);
    }
}
