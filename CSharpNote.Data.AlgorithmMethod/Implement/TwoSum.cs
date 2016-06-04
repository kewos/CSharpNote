using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/two-sum/
    //Given an array of integers, find two numbers such that they add up to a specific target number.
    //The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.
    //You may assume that each input would have exactly one solution.
    //Input: numbers={2, 7, 11, 15}, target=9
    //Output: index1=1, index2=2
    public class TwoSum : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var input = new List<int> {2, 7, 2, 11, 15};
            var target = 9;

            FindMatchTargetIndex(input, target).DumpMany();
        }

        private IEnumerable<List<int>> FindMatchTargetIndex(List<int> numberList, int target)
        {
            var sets = new List<List<int>>();
            var index = 0;
            var range = 0;
            while (index + range < numberList.Count)
            {
                target -= numberList[index + range];
                if (target == 0)
                    sets.Add(new List<int> {index, index + range});

                if (target > 0)
                    range++;
                else
                    target += numberList[index++];
            }

            return sets;
        }
    }
}