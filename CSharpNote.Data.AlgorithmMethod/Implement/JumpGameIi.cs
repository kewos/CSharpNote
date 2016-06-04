using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/jump-game-ii/
    //Given an array of non-negative integers, you are initially positioned at the first index of the array.
    //Each element in the array represents your maximum jump length at that position.
    //Your goal is to reach the last index in the minimum number of jumps.
    //For example:
    //Given array A = [2,3,1,1,4]
    //The minimum number of jumps to reach the last index is 2. (Jump 1 step from index 0 to 1, then 3 steps to the last index.)
    public class JumpGameIi : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var testA = new List<int> {2, 3, 1, 1, 4};
            Console.WriteLine(CheckJumpGameMinStep(testA));
        }

        private int CheckJumpGameMinStep(List<int> array, int position = 0, int step = 0)
        {
            var lastIndex = array.Count() - 1;
            if (array[position] == 0 || position > lastIndex)
                return default(int);

            return position == lastIndex
                ? step
                : Enumerable.Range(1, array[position]).Min(n => CheckJumpGameMinStep(array, position + n, step + 1));
        }
    }
}