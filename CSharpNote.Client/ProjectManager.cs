using System;
using CSharpNote.Common.Extendsions;
using CSharpNote.Core.Contracts;

namespace CSharpNote.Client
{
    public class ProjectManager : IProjectManager
    {
        private readonly IRepositoryManager methodRepositories;
        private readonly IMethodManager methodManager;

        public ProjectManager(IRepositoryManager methodRepositories, IMethodManager methodManager)
        {
            if (methodRepositories == null)
                throw new ArgumentNullException("ArgumentNullException");
            if (methodManager == null)
                throw new ArgumentNullException("ArgumentNullException");

            this.methodRepositories = methodRepositories;
            this.methodManager = methodManager;
        }

        public void Start()
        {
            methodRepositories
                .GetRepositoryNames()
                .SelectAndShowOnConsole(index => Excute(index));
        }

        #region private method
        private void Excute(int index)
        {
            var repository = methodRepositories.GetRepositoryByIndex(index);
            methodManager.Start(repository);
        }
        #endregion private member
    }
}
