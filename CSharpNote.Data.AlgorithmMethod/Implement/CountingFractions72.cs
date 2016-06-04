using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// Consider the fraction, n/d, where n and d are positive integers. If n
    /// <d and HCF( n, d)=1, it is called a reduced proper fraction.
    ///     If we list the set of reduced proper fractions for d ≤ 8 in ascending order of size, we get:
    ///     1/8, 1/7, 1/6, 1/5, 1/4, 2/7, 1/3, 3/8, 2/5, 3/7, 1/2, 4/7, 3/5, 5/8, 2/3, 5/7, 3/4, 4/5, 5/6, 6/7, 7/8
    ///     It can be seen that there are 21 elements in this set.
    ///     How many elements would be contained in the set of reduced proper fractions for d
    /// ≤
    /// 1
    /// ,
    /// 0
    /// 0
    /// 0
    /// ,
    /// 0
    /// 0
    /// 0
    /// ?
    public class CountingFractions72 : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var max = 100;
            var sum = 0;
            var obj = new object();

            var sw = new Stopwatch();
            sw.Start();
            var primes = max.PrimesWithinRange();
            Parallel.ForEach(Enumerable.Range(1, max), fractionM =>
            {
                Parallel.ForEach(Enumerable.Range(1, fractionM - 1), fractionC =>
                {
                    lock (obj)
                    {
                        if (
                            primes.Where(prime => prime <= fractionC)
                                .Any(prime => fractionM%prime == 0 && fractionC%prime == 0))
                            sum++;
                    }
                });
            });

            sw.Stop();
            Console.WriteLine("{0}:{1}", sum, sw.ElapsedMilliseconds);
        }
    }
}