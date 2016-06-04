using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Determine whether an integer is a palindrome. Do this without extra space.
    //Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.
    //If the last word does not exist, return 0.
    //Note: A word is defined as a character sequence consists of non-space characters only.
    //For example, 
    //Given s = "Hello World",
    //return 5.
    public class LengthofLastWord : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/longest-common-prefix/")]
        public override void Execute()
        {
            Console.WriteLine(GetLastWordLength("Hello World"));
        }

        private int GetLastWordLength(string s)
        {
            var postion = s.Length - 1;
            while (postion >= 0 && s[postion] != ' ')
                postion--;

            return s.Length - 1 - postion;
        }
    }
}