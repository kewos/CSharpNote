using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, find the area of largest rectangle in the histogram.
    //The largest rectangle is shown in the shaded area, which has area = 10 unit.
    //For example,
    //Given height = [2,1,5,6,2,3],
    //return 10.
    public class LargestRectangleinHistogram : AbstractExecuteModule
    {
        [MarkedItem(@"https://oj.leetcode.com/problems/largest-rectangle-in-histogram/")]
        public override void Execute()
        {
            var set = new List<int> { 2, 1, 5, 6, 2, 3 };
            var max = 0;
            for (var x = 0; x < set.Count() - 1; x++)
            {
                for (var y = x; y < set.Count(); y++)
                {
                    var area = Math.Min(set[x], set[y]) * (y - x);
                    max = Math.Max(max, area);
                }
            }

            Console.WriteLine(max);
        }
    }
}