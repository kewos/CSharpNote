using System;
using System.Linq;
using ConsoleDisplay.Core.Contracts;
using ConsoleDisplay.Client.Contrasts;
using ConsoleDisplay.Common.Extendsions;

namespace ConsoleDisplay.Client
{
    /// <summary>
    /// 方法管理
    /// </summary>
    public class MethodManager : IMethodManager
    {
        public void Start(IMethodRepository repository)
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
