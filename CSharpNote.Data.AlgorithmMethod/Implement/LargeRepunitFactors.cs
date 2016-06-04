using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// A number consisting entirely of ones is called a repunit. We shall define R(k) to be a repunit of length k.
    /// For example, R(10) = 1111111111 = 11⊙41⊙271⊙9091, and the sum of these prime factors is 9414.
    /// Find the sum of the first forty prime factors of R(109).
    public class LargeRepunitFactors : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            Console.WriteLine(Calulate(10));
        }

        private int Calulate(int length)
        {
            var number = ConvertToNumberLoop(length);
            var query = GetFactorOfPrimes(number).Take(4);
            return query.Sum();
        }

        /// <summary>
        ///     眔计借计
        /// </summary>
        /// <param name="number">惠耞计</param>
        /// <returns>借计计</returns>
        private IEnumerable<int> GetFactorOfPrimes(int number)
        {
            return Enumerable.Range(2, (int) Math.Sqrt(number) - 1)
                .AsParallel().AsOrdered()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .Where(x =>
                    Enumerable.Range(2, (int) Math.Sqrt(x)).All(y => x%y != 0) ||
                    x == 2)
                .Where(x => number%x == 0);
        }

        private int ConvertToNumberLoop(int length)
        {
            var sb = new StringBuilder();
            foreach (var n in Enumerable.Repeat("1", length)) sb.Append(n);

            return int.Parse(sb.ToString());
        }
    }
}