using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target. Return the sum of the three integers. You may assume that each input would have exactly one solution.
    //For example, given array S = {-1 2 1 -4}, and target = 1.
    //The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
    public class Sum3Closest : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/3sum-closest/")]
        public override void Execute()
        {
            var set = new[] {1, 2, 5, 7, -4, -4, 10, 9, 7};

            Console.WriteLine(GetCloseSet(set, -10));
        }

        private int GetCloseSet(int[] nums, int target)
        {
            var x = 0;
            var y = 1;
            var z = 2;
            var min = nums.Max();
            var count = nums.Count();
            while (!(x == count - 3 && y == count - 2 && z == count - 1))
            {
                var close = Math.Abs(target - (nums[x] + nums[y] + nums[z]));
                min = Math.Min(min, close);
                if (y == count - 2 && z == count - 1)
                {
                    y = ++x + 1;
                    z = x + 2;
                }
                else if (z == count - 1)
                {
                    z = ++y + 1;
                }
                else
                {
                    ++z;
                }
            }

            return min;
        }
    }
}