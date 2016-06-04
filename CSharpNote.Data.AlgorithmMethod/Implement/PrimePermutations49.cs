using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: (i) each of the three terms are prime, and, (ii) each of the 4-digit numbers are permutations of one another.
    /// There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, but there is one other 4-digit increasing sequence.
    /// What 12-digit number do you form by concatenating the three terms in this sequence?
    public class PrimePermutations49 : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var digit = 4;
            foreach (
                var number in
                    Enumerable.Range((int) Math.Pow(10, digit - 1),
                        (int) (Math.Pow(10, digit) - Math.Pow(10, digit - 1))))
            {
                foreach (var step in Enumerable.Range(0, (int) (Math.Pow(10, digit) - number)/3))
                {
                    var term1 = number + step;
                    var term2 = number + step*2;
                    var term3 = number + step*3;
                    if (term1 == 1487 && term1.IsPrime() && term2.IsPrime() && term3.IsPrime())
                        Console.WriteLine("{0}:{1}:{2}", term1, term2, term3);
                }
            }

            Console.WriteLine(53.IsPrime());
        }
    }
}