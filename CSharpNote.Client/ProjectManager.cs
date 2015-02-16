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
            methodManager.AssertNotNull();
            methodManager.AssertNotNull();

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
            methodManager.Start(methodRepositories[index]);
        }
        #endregion private member
    }
}
