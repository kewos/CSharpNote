using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ConsoleDisplay.Common;
using ConsoleDisplay.Core.Contracts;
using ConsoleDisplay.Client.Contrasts;

namespace ConsoleDisplay.Client
{
    /// <summary>
    /// 方法管理
    /// </summary>
    public class MethodManager : IMethodManager
    {
        public void Display(IMethodRepository repository)
        {
            repository.MethodInfos.Select(method => method.Name).SelectAndShowOnConsole(index => Excute(index, repository));
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
