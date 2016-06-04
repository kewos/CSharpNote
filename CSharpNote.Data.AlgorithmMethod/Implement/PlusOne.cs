using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given a non-negative number represented as an array of digits, plus one to the number.
    //The digits are stored such that the most significant digit is at the head of the list.
    public class PlusOne : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/plus-one/")]
        public override void Execute()
        {
            var num1 = new List<int> {9, 2, 5};
            var num2 = new List<int> {3, 2, 5};

            GetPlusOne(num1, num2).Dump();
        }

        private List<int> GetPlusOne(List<int> num1, List<int> num2)
        {
            var sum = new Stack<int>();
            var max = Math.Max(num1.Count, num2.Count);
            var nextPlus = 0;
            for (var i = 0; i < max; i++)
            {
                var current = 0;
                current += nextPlus;
                if (i < num1.Count)
                    current += num1[num1.Count - 1 - i];

                if (i < num2.Count)
                    current += num2[num2.Count - 1 - i];

                nextPlus = current/10;
                sum.Push(current%10);
            }

            if (nextPlus != 0)
                sum.Push(nextPlus);

            return sum.ToList();
        }
    }
}