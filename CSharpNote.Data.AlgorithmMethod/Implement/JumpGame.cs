using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    [AopClassAttribue]
    public class JumpGame : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            //https://oj.leetcode.com/problems/jump-game/
            //Given an array of non-negative integers, you are initially positioned at the first index of the array.
            //Each element in the array represents your maximum jump length at that position.
            //Determine if you are able to reach the last index.
            //For example:
            //A = [2,3,1,1,4], return true.
            //A = [3,2,1,0,4], return false.
            var testA = new List<int> {2, 3, 1, 1, 4};
            var testB = new List<int> {3, 2, 1, 0, 4};
            Console.WriteLine(CheckJumpGame(testA));
            Console.WriteLine(CheckJumpGame(testB));
        }

        private bool CheckJumpGame(List<int> array)
        {
            var position = 0;
            var lastIndex = array.Count() - 1;
            while (position < lastIndex)
            {
                if (array[position] == 0)
                    break;

                position += array[position];
            }

            return (position == lastIndex);
        }
    }
}