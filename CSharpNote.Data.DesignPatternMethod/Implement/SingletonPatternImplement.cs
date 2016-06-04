using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.SingletonPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class SingletonPatternImplement : AbstractExecuteModule
    {
        /// <summary>
        ///     於單執行緒三種都產生單一實體
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            Action<string, Func<int>> check = (msg, func) =>
            {
                var hashcode = func();
                var list = Enumerable.Range(0, 1000)
                    .Select(n =>
                        func());
                list.All(n => n == hashcode).ToConsole(msg);
                list.Count().ToConsole();
            };

            check("CheckSingletonA", () => SingletonA.Instance().GetHashCode());
            check("CheckSingletonB", () => SingletonB.Instance().GetHashCode());
            check("CheckSingletonC", () => SingletonC.Instance().GetHashCode());
        }
    }
}