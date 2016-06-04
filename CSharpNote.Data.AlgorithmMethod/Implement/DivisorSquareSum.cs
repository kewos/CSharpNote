using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// Problem 211
    /// For a positive integer n, let 2(n) be the sum of the squares of its divisors. For example,
    /// 2(10) = 1 + 4 + 25 + 100 = 130.
    /// Find the sum of all n, 0
    /// < n
    /// < 64,000,000 such that 2( n) is a perfect square.
    public class DivisorSquareSum : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var obj = new object();
            var sw = new Stopwatch();
            sw.Start();
            Parallel.ForEach(Enumerable.Range(1, 64000), number =>
            {
                lock (obj)
                {
                    var factors = number.Factor();
                    var sum = GetSequenceSquareSum(factors);
                    if (CheckPerfectSquare(sum))
                        Console.WriteLine(number);
                }
            });

            sw.Stop();
            Console.WriteLine("SpentTime:{0}ms", sw.ElapsedMilliseconds);
        }

        /// <summary>
        ///     耞琌Чキよ计
        /// </summary>
        /// <param name="numbers">惠耞计</param>
        /// <returns></returns>
        private bool CheckPerfectSquare(double number)
        {
            return (Math.Sqrt(number)%1) == 0;
        }

        /// <summary>
        ///     眔场计キよ羆
        /// </summary>
        /// <param name="numbers">惠キよ羆计</param>
        /// <returns>キよ羆</returns>
        private double GetSequenceSquareSum(List<int> numbers)
        {
            var obj = new object();
            double sum = 0;

            Parallel.ForEach(numbers, number =>
            {
                lock (obj)
                {
                    sum += Math.Pow(number, 2);
                }
            });

            return sum;
        }
    }
}