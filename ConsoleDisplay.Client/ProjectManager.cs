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
        private List<Type> MethodRepositories;
        private IConsoleDisplayer consoleDisplayer;
        private IMethodManager methodManager;

        public ProjectManager(
            IMethodRepositoryFactory factory, 
            IConsoleDisplayer consoleDisplayer, 
            IMethodManager methodManager)
        {
            this.MethodRepositories = factory.MethodRepositoryTypes.Select(n => n.Value).ToList();
            this.consoleDisplayer = consoleDisplayer;
            this.methodManager = methodManager;
        }

        public void Display()
        {
            consoleDisplayer.Excute(MethodRepositories.Select(n => n.Name), index => Excute(index));
        }

        /// <summary>
        /// 執行所選擇的專案
        /// </summary>
        /// <param name="index">選擇的專案</param>
        private void Excute(int index)
        {
            var project = Activator.CreateInstance(MethodRepositories[index]) as IMethodRepository;
            methodManager.Display(project);
        }
    }
}
