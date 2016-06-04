using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given a string S and a string T, count the number of distinct subsequences of T in S.
    //A subsequence of a string is a new string which is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (ie, "ACE" is a subsequence of "ABCDE" while "AEC" is not).
    //Here is an example:
    //S = "rabbbit", T = "rabbit"
    //Return 3.
    public class DistinctSubsequences : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/distinct-subsequences/")]
        public override void Execute()
        {
            var s = "aarabbbit";
            var t = "rabbit";

            Console.WriteLine(GetDistinctSubsequences(s, t));
        }

        private int GetDistinctSubsequences(string s, string t)
        {
            var stime = SequenceRepeatTimes(s);
            var ttime = SequenceRepeatTimes(t);
            if (stime.Count != ttime.Count)
                return 0;

            var all = 1;
            for (var i = 0; i < stime.Count; i++)
            {
                if (stime[i].Key != ttime[i].Key || stime[i].Value < ttime[i].Value)
                    return 0;

                if (stime[i].Value > ttime[i].Value)
                    all *= AllGroup(stime[i].Value, ttime[i].Value);
            }

            return all;
        }

        private int AllGroup(int x, int y)
        {
            var i = Enumerable.Range(1, y).Aggregate((a, b) => a*b);
            var j = Enumerable.Range(x - y + 1, y).Aggregate((a, b) => a*b);

            return i/j;
        }

        private List<KeyValuePair<char, int>> SequenceRepeatTimes(string s)
        {
            var repeat = new List<KeyValuePair<char, int>>();
            for (var i = 0; i < s.Length; i++)
            {
                if (i == 0 || s[i] != s[i - 1])
                {
                    repeat.Add(new KeyValuePair<char, int>(s[i], 1));
                    continue;
                }

                repeat[repeat.Count - 1] = new KeyValuePair<char, int>(repeat.Last().Key, repeat.Last().Value + 1);
            }

            return repeat;
        }
    }
}