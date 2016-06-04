using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Implement int sqrt(int x).
    //Compute and return the square root of x.
    public class ImplementSqrt : AbstractExecuteModule
    {
        [MarkedItem(@"https://oj.leetcode.com/problems/sqrtx/")]
        public override void Execute()
        {
            Console.WriteLine(GetSqrt(15));
        }

        private long GetSqrt(int x)
        {
            long ans = 0;
            var bit = 1l << 16;
            while (bit > 0)
            {
                ans |= bit;
                if (ans * ans > x)
                {
                    ans ^= bit;
                }

                bit >>= 1;
            }

            return ans;
        }
    }
}