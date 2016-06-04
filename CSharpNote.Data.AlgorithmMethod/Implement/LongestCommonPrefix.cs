using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Write a function to find the longest common prefix string amongst an array of strings.
    public class LongestCommonPrefix : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/longest-common-prefix/")]
        public override void Execute()
        {
            var items = new string[] {};

            DoLongestCommonPrefix(items).ToConsole();
        }

        private string DoLongestCommonPrefix(string[] items)
        {
            if (items == null || items.Length <= 0)
                return string.Empty;

            var last = items[0].Length;
            for (var i = 1; i < items.Length; i++)
            {
                if (last == 0)
                    return string.Empty;

                last = Math.Min(last, items[i].Length);
                while (last > 0 && items[i].Substring(0, last) != items[0].Substring(0, last))
                    last--;
            }

            return items[0].Substring(0, last);
        }
    }
}