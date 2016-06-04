using System;
using System.Linq;
using System.Threading.Tasks;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class ParallelForeach : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var obj = new object();
            var obj1 = new object();
            var count = 0;
            Parallel.For(1, 10 + 1, num =>
            {
                lock (obj)
                {
                    Parallel.For(1, num + 1, num1 =>
                    {
                        lock (obj1)
                        {
                            count += num1;
                        }
                    });
                }
            });
            Console.WriteLine(count);

            Parallel.ForEach(Enumerable.Range(0, 10000), (num, state) =>
            {
                lock (obj)
                {
                    if (num == 500) state.Break();
                    Console.WriteLine(num);
                }
            });
        }
    }
}