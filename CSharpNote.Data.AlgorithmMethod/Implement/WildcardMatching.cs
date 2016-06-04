using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/wildcard-matching/
    //'?' Matches any single character.
    //'*' Matches any sequence of characters (including the empty sequence).
    //The matching should cover the entire input string (not partial).
    //The function prototype should be:
    //bool isMatch(const char *s, const char *p)
    //Some examples:
    //isMatch("aa","a") ¡÷ false
    //isMatch("aa","aa") ¡÷ true
    //isMatch("aaa","aa") ¡÷ false
    //isMatch("aa", "*") ¡÷ true
    //isMatch("aa", "a*") ¡÷ true
    //isMatch("ab", "?*") ¡÷ true
    //isMatch("aab", "c*a*b") ¡÷ false
    public class WildcardMatching : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            Console.WriteLine(IsMatch("aa", "a"));
            Console.WriteLine(IsMatch("aa", "aa"));
            Console.WriteLine(IsMatch("aaa", "aa"));
            Console.WriteLine(IsMatch("aa", "*"));
            Console.WriteLine(IsMatch("aa", "a*"));
            Console.WriteLine(IsMatch("ab", "?*"));
            Console.WriteLine(IsMatch("aab", "c*a*b"));
        }

        private bool IsMatch(string checkString, string validateString)
        {
            if (!validateString.Contains("*") && !validateString.Contains("?"))
                return checkString.Equals(validateString);

            var postion = 0;
            var bondary = checkString.Length - 1;
            foreach (var c in validateString.TakeWhile(c => postion <= bondary).Where(c => !c.Equals('*')))
            {
                if (c.Equals('?'))
                {
                    postion++;
                    continue;
                }

                if (checkString[postion].Equals(c))
                {
                    postion++;
                    continue;
                }

                while (postion <= bondary && !checkString[postion].Equals(c)) postion++;
            }

            return postion <= bondary;
        }
    }
}