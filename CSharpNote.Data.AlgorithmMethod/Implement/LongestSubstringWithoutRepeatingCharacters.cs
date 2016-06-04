using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/longest-substring-without-repeating-characters/
    //Given a string, find the length of the longest substring without repeating characters. For example, the longest substring without repeating letters for "abcabcbb" is "abc", 
    //which the length is 3. For "bbbbb" the longest substring is "b", with the length of 1.
    public class LongestSubstringWithoutRepeatingCharacters : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            var test = "aaaaaaaaaaaaaaaaaaefc";

            Console.WriteLine(GetLengthWithoutRepeat(test));
        }

        private int GetLengthWithoutRepeat(string checkString)
        {
            var stringMax = checkString.Distinct().Count();
            var noRepeatLength = 3;
            var index = 0;
            if (stringMax <= 3) return stringMax;
            while (index < checkString.Length)
            {
                var stringInternal = noRepeatLength + 1;
                if (index + stringInternal > checkString.Length)
                    break;

                if (stringInternal != checkString.Substring(index, stringInternal).Distinct().Count())
                {
                    index++;
                    continue;
                }

                if (stringInternal > noRepeatLength)
                    noRepeatLength = stringInternal;
                else
                    index++;

                if (noRepeatLength == stringMax)
                    break;
            }

            return noRepeatLength;
        }
    }
}