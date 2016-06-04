using System;
using System.Diagnostics;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class CalculatePrimesWithParallelLinq : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var maxNumber = 10000;
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            foreach (var prime in
                from n in Enumerable.Range(2, maxNumber - 1)
                    .AsParallel()
                    .AsOrdered()
                    .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                where n == 2 || Enumerable.Range(2, (int) Math.Sqrt(n)).All(testNum => n%testNum != 0)
                select n)
            {
                Console.WriteLine(prime);
            }
            stopwatch.Stop();

            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
        }
    }
}