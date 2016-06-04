using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// Problem 443
    /// Let g(n) be a sequence defined as follows:
    /// g(4) = 13,
    /// g(n) = g(n-1) + gcd(n, g(n-1)) for n > 4.
    /// The first few values are:
    /// n	4	5	6	7	8	9	10	11	12	13	14	15	16	17	18	19	20	...
    /// g(n)	13	14	16	17	18	27	28	29	30	31	32	33	34	51	54	55	60	...
    /// You are given that g(1 000) = 2524 and g(1 000 000) = 2624152.
    /// Find g(1015).
    public class GetGcdSequence : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var dictionary = new Dictionary<int, int> {{4, 13}};

            foreach (var number in Enumerable.Range(5, 10000))
            {
                var currentResult = dictionary[number - 1] + GetGcd(number, dictionary[number - 1]);
                dictionary.Add(number, currentResult);

                Console.WriteLine("index:{0} number:{1}", number, currentResult);
            }
        }

        /// <summary>
        ///     取得最大公因數
        /// </summary>
        /// <param name="number1">需判斷數字1</param>
        /// <param name="number2">需判斷數字2</param>
        /// <returns>最大公因數</returns>
        private int GetGcd(int number1, int number2)
        {
            var factors1 = number1.Factor();
            var factors2 = number2.Factor();

            return factors1.Intersect(factors2).Max();
        }
    }
}