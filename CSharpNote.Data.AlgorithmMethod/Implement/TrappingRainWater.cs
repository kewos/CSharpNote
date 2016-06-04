using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/trapping-rain-water/
    //Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.
    //For example, 
    //Given [0,1,0,2,1,0,1,3,2,1,2,1], return 6.
    public class TrappingRainWater : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var elements = new List<int> {0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1};
            var sum = 0;
            var intervals = new List<List<int>>();
            for (var i = 0; i < elements.Count; i++)
            {
                for (var j = i + 1; j < elements.Count; j++)
                {
                    if (elements[j] < elements[i])
                        continue;

                    if (!(intervals.Any(interval => interval[0] <= i
                                                    && interval[1] >= j))
                        && j - i > 1)
                    {
                        intervals.Add(new List<int> {i, j});
                        var min = Math.Min(elements[i], elements[j]);
                        sum += Enumerable.Range(i + 1, j - i - 1).Sum(index => min - elements[index]);
                    }

                    break;
                }
            }

            Console.WriteLine(sum);
            intervals.ForEach(n => Console.WriteLine("[{0},{1}]", n[0], n[1]));
        }
    }
}