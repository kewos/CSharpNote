using System;
using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given a string s and a dictionary of words dict, determine if s can be segmented into a space-separated sequence of one or more dictionary words.
    //For example, given
    //s = "leetcode",
    //dict = ["leet", "code"].
    //Return true because "leetcode" can be segmented as "leet code".
    public class WordBreak : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/word-break/")]
        public override void Execute()
        {
            var dict = new List<string> {"leet", "code"};
            var s = "leetcode";

            Console.WriteLine(GetWordBreak(dict, s));
        }

        private bool GetWordBreak(List<string> dict, string s)
        {
            var stringIndex = 0;
            var dictIndex = 0;
            while (dictIndex < dict.Count && stringIndex + dict[dictIndex].Length - 1 < s.Length)
            {
                if (s.Substring(stringIndex, dict[dictIndex].Length) == dict[dictIndex])
                {
                    stringIndex += dict[dictIndex].Length - 1;
                    dictIndex++;
                }

                stringIndex++;
            }

            return dictIndex >= dict.Count;
        }
    }
}