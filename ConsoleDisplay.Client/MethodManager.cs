using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ConsoleDisplay.Common;
using ConsoleDisplay.Data.Implements;
using ConsoleDisplay.Data.Contracts;

namespace ConsoleDisplay.Client
{
    public interface IMethodManager
    {
        /// <summary>
        /// 呈現方法清單
        /// </summary>
        /// <param name="repository">執行的方案</param>
        void Display(IMethodRepository repository);
    }

    /// <summary>
    /// 方法管理
    /// </summary>
    public class MethodManager : IMethodManager
    {
        private IConsoleDisplayer consoleDisplayer;
        /// <summary>
        /// Singleton Pattern
        /// </summary>
        public MethodManager(IConsoleDisplayer consoleDisplayer) 
        {
            this.consoleDisplayer = consoleDisplayer;
        }

        public void Display(IMethodRepository repository)
        {
            var items = repository.MethodInfos.Select(method => method.Name);
            consoleDisplayer.Excute(items, index => Excute(index, repository));
        }

        private void Excute(int index, IMethodRepository repository)
        {
            if (index >= repository.MethodInfos.Count || index < 0)
            {
                throw new ArgumentException("invalid argument");
            }

            repository.MethodInfos[index].Invoke(repository, null);
        }
    }
}
