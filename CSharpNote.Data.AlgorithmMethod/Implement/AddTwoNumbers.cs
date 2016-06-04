using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/add-two-numbers/
    //You are given two linked lists representing two non-negative numbers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
    //Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
    //Output: 7 -> 0 -> 8
    public class AddTwoNumbers : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var n1 = new List<int> {2, 4, 6};
            var n2 = new List<int> {5, 6, 4};
            var count = new List<int>();
            var maxLength = Math.Max(n1.Count, n2.Count);
            var temp = 0;
            foreach (var index in Enumerable.Range(0, maxLength))
            {
                var x = 0;
                var y = 0;
                if (index <= n1.Count - 1)
                    x = n1[index];

                if (index <= n2.Count - 1)
                    y = n2[index];

                count.Add((x + y)%10 + temp);
                temp = (x + y)/10;
            }

            count.Add(temp);
        }
    }
}