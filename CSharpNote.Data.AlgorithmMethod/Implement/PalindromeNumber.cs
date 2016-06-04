using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Determine whether an integer is a palindrome. Do this without extra space.
    public class PalindromeNumber : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/longest-common-prefix/")]
        public override void Execute()
        {
            var i = 77801120877;

            Console.WriteLine("{0}:IsPalindromeNumber:{1}", i, IsPalindromeNumber(i));
        }

        private bool IsPalindromeNumber(long i)
        {
            var s = i.ToString();
            for (var j = 0; j < s.Length/2; j++)
            {
                if (s[j] != s[s.Length - 1 - j])
                    return false;
            }

            return true;
        }
    }
}