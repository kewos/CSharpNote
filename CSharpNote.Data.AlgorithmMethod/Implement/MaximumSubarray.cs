using System;
using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Find the contiguous subarray within an array (containing at least one number) which has the largest sum.
    //For example, given the array [−2,1,−3,4,−1,2,1,−5,4],
    //the contiguous subarray [4,−1,2,1] has the largest sum = 6.
    public class MaximumSubarray : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/maximum-subarray/")]
        public override void Execute()
        {
            var array = new List<int> {-2, 1, -3, 4, -1, 2, 1, -5, 4};

            Console.WriteLine(GetMaximumSubarray(array));
        }

        private int GetMaximumSubarray(List<int> array)
        {
            var index1 = 0;
            var index2 = 0;
            var currentSum = 0;
            var max = array[0];
            while (index1 < array.Count - 1)
            {
                if (index2 >= array.Count)
                {
                    index2 = ++index1;
                    currentSum = 0;
                }

                currentSum += array[index2++];
                max = Math.Max(max, currentSum);
            }

            return max;
        }
    }
}