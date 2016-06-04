using System;
using System.Linq;
using System.Threading;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class ChecklockThis : AbstractExecuteModule
    {
        /// <summary>
        ///     lockThis 是一種不安全的方式 除非Class是唯一
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            Action check1 = () =>
            {
                var threads = Enumerable.Range(0, 5)
                    .Select(n =>
                        new Thread(() => new TestLockThis().Execute()))
                    .ToList();

                threads.ForEach(thread => thread.Start());
                SpinWait.SpinUntil(() => !threads.Any(thread => thread.IsAlive), 100);
            };

            Action check2 = () =>
            {
                var testItem = new TestLockThis();
                var threads = Enumerable.Range(0, 5)
                    .Select(n =>
                        new Thread(() => testItem.Execute()))
                    .ToList();

                threads.ForEach(thread => thread.Start());
                SpinWait.SpinUntil(() => !threads.Any(thread => thread.IsAlive), 100);
            };

            check1.CaculateExcuteTime().ToConsole("Check1 ExcuteTime:");
            check2.CaculateExcuteTime().ToConsole("Check2 ExcuteTime:");
        }

        private class TestLockThis
        {
            public void Execute()
            {
                lock (this)
                {
                    Enumerable.Range(1, 20)
                        .ForEach(n =>
                            Console.WriteLine("ThreadId:{0}-{1}", Thread.CurrentThread.ManagedThreadId, n));
                }
            }
        }
    }
}