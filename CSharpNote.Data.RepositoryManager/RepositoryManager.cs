using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using CSharpNote.Common.Extendsions;
using CSharpNote.Core.Contracts;

namespace CSharpNote.Data.RepositoryManager
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IList<IMethodRepository> methodRepositories;

        #region constructor
        public RepositoryManager(IEnumerable<IMethodRepository> methodRepositories)
        {
            this.methodRepositories = methodRepositories.ToList();
        }
        #endregion

        #region IRepositoryManager member

        public int Count
        {
            get
            {
                return methodRepositories.Count;
            }
        }

        public IEnumerable<string> GetRepositoryNames()
        {
            return methodRepositories.Select(repository => repository.RepositoryName);
        }

        public IMethodRepository this[int index]
        {
            get
            {
                index.AssertBetweenRange(0, Count - 1);

                return methodRepositories[index];
            }
        }
        #endregion
    }
}
