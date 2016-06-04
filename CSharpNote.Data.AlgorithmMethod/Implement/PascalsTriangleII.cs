using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given an index k, return the kth row of the Pascal's triangle.
    //For example, given k = 3,
    //Return [1,3,3,1].
    //Note:
    //Could you optimize your algorithm to use only O(k) extra space?
    public class PascalsTriangleII : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/pascals-triangle-ii/")]
        public override void Execute()
        {
            GetPascalsTriangleII(3).Dump();
        }

        private List<int> GetPascalsTriangleII(int k)
        {
            var space = new List<int> {1};
            var index = 0;
            while (index < k)
            {
                space.Add(space[0]);
                for (var i = index; i > 0; i--)
                {
                    space[i] += space[i - 1];
                }

                index++;
            }

            return space;
        }
    }
}