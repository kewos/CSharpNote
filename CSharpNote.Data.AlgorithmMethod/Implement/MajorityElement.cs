using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.
    //You may assume that the array is non-empty and the majority element always exist in the array.
    public class MajorityElement : AbstractExecuteModule
    {
        [MarkedItem(@"https://oj.leetcode.com/problems/majority-element/")]
        public override void Execute()
        {
            var elements = new List<int> { 1, 3, 1, 1, 5, 1, 9, 1, 1, 7, 1 };

            GetMajorityElement(elements).ToConsole();
        }

        private int GetMajorityElement(List<int> elements)
        {
            var dic = new Dictionary<int, int>();
            foreach (var e in elements)
            {
                if (!dic.ContainsKey(e))
                    dic.Add(e, 1);
                else
                    dic[e]++;
            }

            return dic.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
        }
    }
}