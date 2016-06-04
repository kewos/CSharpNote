using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class DistinctSubsequences¢¹ : AbstractExecuteModule
    {
        [MarkedItem(@"https://oj.leetcode.com/discuss/2143/any-better-solution-that-takes-less-than-space-while-in-time")]
        public override void Execute()
        {
            var s = "aaa";
            var t = "a";

            Console.WriteLine(GetDistinctSubsequences¢¹(s, t));
        }

        private int GetDistinctSubsequences¢¹(string s, string t)
        {
            var m = s.Length;
            var n = t.Length;
            if (m < n)
                return 0;

            var path = Enumerable.Range(0, n + 1).Select(i => 0).ToList();
            path[0] = 1;

            for (var i = 1; i <= m; i++)
            {
                for (var j = n; j >= 1; j--)
                {
                    path[j] += (s[i - 1] == t[j - 1]) ? path[j - 1] : 0;
                }
            }

            return path[n];
        }
    }
}