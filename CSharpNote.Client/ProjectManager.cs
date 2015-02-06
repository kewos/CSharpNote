using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Extendsions;
using CSharpNote.Core.Contracts;
using CSharpNote.Client.Contrasts;

namespace CSharpNote.Client
{
    /// <summary>
    /// 專案管理
    /// </summary>
    public class ProjectManager : IProjectManager
    {
        private readonly IEnumerable<IMethodRepository> methodRepositories;
        private readonly IMethodManager methodManager;
        private const string TRIMSTRING = "MethodRepository";

        public ProjectManager(IEnumerable<IMethodRepository> methodRepositories, IMethodManager methodManager)
        {
            this.methodRepositories = methodRepositories;
            this.methodManager = methodManager;
        }

        public void Start()
        {
            methodRepositories
                .Select(repository => trimString(repository))
                .SelectAndShowOnConsole(index => Excute(index));
        }

        #region private method
        /// <summary>
        /// 取得沒有 TRIMSTRING 的 IMethodRepository TypeName
        /// </summary>
        private readonly Func<IMethodRepository, string> trimString = (repository) =>
        {
            var typeName = repository.GetType().Name;
            var stringEnd = typeName.Length - TRIMSTRING.Length;
            return typeName.Substring(0, stringEnd);
        };

        /// <summary>
        /// 執行所選擇的專案
        /// </summary>
        /// <param name="index">選擇的專案</param>
        private void Excute(int index)
        {
            var repository = methodRepositories.Skip(index).FirstOrDefault();
            methodManager.Start(repository);
        }
        #endregion private member
    }
}
