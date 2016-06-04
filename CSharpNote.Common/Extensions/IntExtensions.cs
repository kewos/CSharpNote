using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpNote.Common.Extensions
{
    public static class IntExtensions
    {
        public static IEnumerable<int> DecomposeNoSignDigit(this int target)
        {
            while (target != 0)
            {
                yield return target%10;
                target /= 10;
            }
        }

        /// <summary>
        /// 取得因子
        /// </summary>
        /// <param name="number">需取得因子數字</param>
        /// <returns>全部因子</returns>
        public static List<int> Factor(this int number)
        {
            var factors = new List<int>();
            foreach (var factor in Enumerable.Range(1, (int)Math.Floor(Math.Sqrt(number))).Where(x => number % x == 0))
            {
                factors.Add(factor);
                if (!factors.Contains(number / factor))
                    factors.Add(number / factor);
            }

            return factors;
        }

        /// <summary>
        ///     取得2~Range之間的prime
        /// </summary>
        /// <param name="range">範圍</param>
        /// <returns>Primes within 2 and range</returns>
        public static IEnumerable<int> PrimesWithinRange(this int range)
        {
            return Enumerable.Range(2, range - 1).Where(x => x.Factor().Count == 2);
        }

        public static bool IsPrime(this int number)
        {
            if (number < 1)
                return false;

            if (number == 2)
                return true;

            return number.PrimesWithinRange().Contains(number);
        } 
    }
}