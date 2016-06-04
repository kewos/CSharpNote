using System;
using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class MaximumSubarray¢¹ : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/maximum-subarray/", true)]
        public override void Execute()
        {
            var array = new List<int> {-2, 1, -3, 4, -1, 2, 1, -5, 4};

            Console.WriteLine(GetMaximumSubarray¢¹(array));
        }

        private int GetMaximumSubarray¢¹(List<int> array)
        {
            var max = array[0];
            var sum = 0;
            foreach (var item in array)
            {
                sum += item;
                max = Math.Max(sum, max);
                sum = Math.Max(sum, 0);
            }

            return max;
        }
    }
}