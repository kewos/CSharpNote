using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.SingletonPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class SingletonPatternAtMutiThread : AbstractExecuteModule
    {
        /// <summary>
        ///     於多執行緒的情況SingletonB SingletonC有可能產生多個實體
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            Action<string, Func<int>> mutiThreadCheck = (msg, func) =>
            {
                var hashcode = func();
                var list = new List<int>();
                var threads = Enumerable.Range(0, 50)
                    .Select(
                        n =>
                        {
                            return new Thread(() => { Enumerable.Range(0, 20).ForEach(m => { list.Add(func()); }); });
                        })
                    .ToList();
                threads.ForEach(thread => thread.Start());
                SpinWait.SpinUntil(() => !threads.Any(thread => thread.IsAlive), 100);
                list.All(n => n == hashcode).ToConsole(msg);
                list.Count.ToConsole();
            };

            mutiThreadCheck.Invoke("SingletonACheck:", () => SingletonA.Instance().GetHashCode());
            mutiThreadCheck.Invoke("SingletonBCheck:", () => SingletonB.Instance().GetHashCode());
            mutiThreadCheck.Invoke("SingletonCCheck:", () => SingletonC.Instance().GetHashCode());
        }
    }
}