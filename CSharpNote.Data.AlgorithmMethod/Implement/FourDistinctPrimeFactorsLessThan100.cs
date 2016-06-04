using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// It can be verified that there are 23 positive integers less than 1000 that are divisible by at least four distinct primes less than 100.
    /// Find how many positive integers less than 1016 are divisible by at least four distinct primes less than 100.
    public class FourDistinctPrimeFactorsLessThan100 : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var primes = 100.PrimesWithinRange();
            var sum =
                Enumerable.Range(1, 1000)
                    .Select(number => primes.Count(prime => number%prime == 0))
                    .Count(matchPrime => matchPrime >= 4);

            Console.WriteLine(sum);
        }
    }
}