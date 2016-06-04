using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class PalindromeNumberIi : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/longest-common-prefix/")]
        public override void Execute()
        {
            //Determine whether an integer is a palindrome. Do this without extra space.
            var i = 7780110877;

            Console.WriteLine("{0}:IsPalindromeNumber:{1}", i, IsPalindromeNumberIi(i));
        }

        private bool IsPalindromeNumberIi(long i)
        {
            for (var j = 0; j < (int) (Math.Log10(i) + 1)/2; j++)
            {
                var one = (int) (i/Math.Pow(10, j)%10);
                var two = (int) (i/Math.Pow(10, (int) (Math.Log10(i) - j)%10));
                if (one != two)
                    return false;
            }

            return true;
        }
    }
}