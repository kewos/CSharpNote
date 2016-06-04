using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// https://oj.leetcode.com/problems/maximum-product-subarray/
    /// Find the contiguous subarray within an array (containing at least one number) which has the largest product.
    /// For example, given the array [2,3,-2,4],
    /// the contiguous subarray [2,3] has the largest product = 6.
    public class FindTheContiguousSubarrayWithinAnArray : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var list = new List<int> {2, 3, -2, 4, 10, -3, 5, -1};
            var subList = new List<int>();
            var max = 0;
            for (var x = 0; x <= list.Count; x++)
            {
                for (var y = 1; x + y <= list.Count; y++)
                {
                    var sub = list.Skip(x).Take(y);
                    var subSumValue = sub.Aggregate((a, b) => a*b);
                    if (subSumValue > max)
                    {
                        max = subSumValue;
                        subList = sub.ToList();
                    }
                }
            }

            var sb = new StringBuilder();
            subList.ForEach(n => sb.Append("[" + n + "]"));
            sb.Append("=" + max);

            Console.WriteLine(sb.ToString());
        }
    }
}