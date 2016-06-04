using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given an unsorted integer array, find the first missing positive integer.
    //For example,
    //Given [1,2,0] return 3,
    //and [3,4,-1,1] return 2.
    //Your algorithm should run in O(n) time and uses constant space.
    public class FirstMissingPositive : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/first-missing-positive/")]
        public override void Execute()
        {
            GetFirstMissingPositive(new[] {4, 3, 4, 1, 1, 4, 1, 4}).ToConsole();
        }

        public int GetFirstMissingPositive(int[] nums)
        {
            if (nums == null || !nums.Any())
                return 1;
            //獶タ俱计竚
            var negativeIndex = -1;
            for (var index1 = 0; index1 < nums.Length; index1++)
            {
                if (nums[index1] <= 0)
                    negativeIndex++;
                //逼
                for (var index2 = index1;
                    index2 > 0 && index2 >= negativeIndex && nums[index2 - 1] > nums[index2];
                    index2--)
                {
                    var temp = nums[index2];
                    nums[index2] = nums[index2 - 1];
                    nums[index2 - 1] = temp;
                }
            }
            //⊿タ俱计
            if (negativeIndex + 1 == nums.Length)
                return 1;
            //狡Ω计
            var duplicate = 0;
            //玡计
            var preNum = 0;
            //絋粄琌竚
            for (var index = negativeIndex + 1; index < nums.Length; index++)
            {
                if (preNum == nums[index])
                {
                    duplicate++;
                    continue;
                }

                if (nums[index] != index - negativeIndex - duplicate)
                    return index - negativeIndex - duplicate;

                preNum = nums[index];
            }
            //程
            return nums[nums.GetUpperBound(0)] + 1;
        }
    }
}