using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/anagrams/
    //Given an array of strings, return all groups of strings that are anagrams.
    //Note: All inputs will be in lower-case.
    public class Anagrams : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            var strs = new List<string> { "dog", "god", "cab", "bac", "zdz", "aac" };
            strs.Where(n =>
            {
                return strs.Any(m =>
                {
                    if (n == m)
                        return false;

                    return string.Concat(n.ToCharArray().OrderBy(x => x)) ==
                           string.Concat(m.ToCharArray().OrderBy(x => x));
                });
            });
        }
    }
}