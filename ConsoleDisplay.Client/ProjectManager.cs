using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ConsoleDisplay.Common;
using ConsoleDisplay.Core.Contracts;
using ConsoleDisplay.Data;
using ConsoleDisplay.Client.Contrasts;

namespace ConsoleDisplay.Client
{
    /// <summary>
    /// 專案管理
    /// </summary>
    public class ProjectManager : IProjectManager
    {
        private readonly IEnumerable<IMethodRepository> methodRepositories;
        private readonly IMethodManager methodManager;

        public ProjectManager(IEnumerable<IMethodRepository> repositorys, IMethodManager methodManager)
        {
            this.methodRepositories = repositorys;
            this.methodManager = methodManager;
        }

        public void Start()
        {
            var dontNeedString = "MethodRepository";
            methodRepositories
                .Select(n => n.GetType().Name.Substring(0, n.GetType().Name.Length - dontNeedString.Length))
                .SelectAndShowOnConsole(index => Excute(index));
        }

        /// <summary>
        /// 執行所選擇的專案
        /// </summary>
        /// <param name="index">選擇的專案</param>
        private void Excute(int index)
        {
            var repository = methodRepositories.Skip(index).FirstOrDefault();
            methodManager.Start(repository);
        }
    }
}
