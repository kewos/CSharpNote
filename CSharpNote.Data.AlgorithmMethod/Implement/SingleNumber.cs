using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given an array of integers, every element appears twice except for one. Find that single one.
    //Note:
    //Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
    public class SingleNumber : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/single-number/")]
        public override void Execute()
        {
            var searchList = new List<int> {1, 2, 2, 3, 1, 6, 3, 4, 4, 5, 5, 5, 5};

            Console.WriteLine(GetSingleNumber(searchList));
        }

        private int GetSingleNumber(List<int> searchList)
        {
            return searchList.Aggregate((a, b) => a ^ b);
        }
    }
}