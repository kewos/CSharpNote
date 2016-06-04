using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/single-number-ii/
    //Given an array of integers, every element appears three times except for one. Find that single one.
    //Note:
    //Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
    public class SingleNumberIi : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var testArray = new List<int> {3, 1, 4, 1, 4, 2, 4, 1, 5, 2, 2, 3, 3};
            var ones = 0;
            var twos = 0;
            for (var i = 0; i < testArray.Count(); i++)
            {
                ones = (ones ^ testArray[i]) & ~twos; //1100 1101
                twos = (twos ^ testArray[i]) & ~ones; //0000 0010
            }

            Console.WriteLine(ones);
        }
    }
}