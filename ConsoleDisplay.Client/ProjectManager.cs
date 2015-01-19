using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ConsoleDisplay.Common;
using ConsoleDisplay.Data.Implements;
using ConsoleDisplay.Data.Contracts;
using ConsoleDisplay.Data;

namespace ConsoleDisplay.Client
{
    public interface IProjectManager
    {
        /// <summary>
        /// 呈現專案清單
        /// </summary>
        void Display();
    }

    /// <summary>
    /// 專案管理
    /// </summary>
    public class ProjectManager : IProjectManager
    {
        private List<Type> methodRepositories;
        private IMethodManager methodManager;

        public ProjectManager(IMethodRepositoryFactory factory, IMethodManager methodManager)
        {
            this.methodRepositories = factory.MethodRepositoryTypes.Select(n => n.Value).ToList();
            this.methodManager = methodManager;
        }

        public void Display()
        {
            var dontNeedString = "MethodRepository";
            methodRepositories
                .Select(n => n.Name.Substring(0, n.Name.Length - dontNeedString.Length))
                .SelectAndShowOnConsole(index => Excute(index));
        }

        /// <summary>
        /// 執行所選擇的專案
        /// </summary>
        /// <param name="index">選擇的專案</param>
        private void Excute(int index)
        {
            var project = Activator.CreateInstance(methodRepositories[index]) as IMethodRepository;
            methodManager.Display(project);
        }
    }
}
