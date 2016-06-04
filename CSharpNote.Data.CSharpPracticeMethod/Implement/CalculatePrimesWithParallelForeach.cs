using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class CalculatePrimesWithParallelForeach : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var maxNumber = 500000;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.ForEach(Enumerable.Range(2, maxNumber), num =>
            {
                lock (this)
                {
                    var isPrime = num == 2 ||
                                  Enumerable.Range(2, (int) Math.Sqrt(num)).All(testNum => num%testNum != 0);
                    if (isPrime) Console.WriteLine(num);
                }
            });
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }
    }
}