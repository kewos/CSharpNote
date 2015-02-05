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

        #region private method
        private void Excute(int index, IMethodRepository repository)
        {
            ArgumentGuard(index, repository.Count - 1, 0);
            repository.MethodInfos[index].Invoke(repository, null);
        }

        private Action<int, int, int> ArgumentGuard = (argument, upperBounded, lowerBounded) =>
        {
            if (argument > upperBounded || argument < lowerBounded)
            {
                throw new ArgumentException("invalid argument");
            }
        };
        #endregion
    }
}
