using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given numRows, generate the first numRows of Pascal's triangle.
    public class PascalsTriangleI : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/pascals-triangle/")]
        public override void Execute()
        {
            GetPascalsTriangleI(5).DumpMany();
        }

        private IEnumerable<List<int>> GetPascalsTriangleI(int k)
        {
            var set = new List<List<int>> {new List<int> {1}};
            for (var i = 1; i <= k; i++)
            {
                var newSet = new List<int>();
                var frontSet = set[i - 1];
                newSet.Add(frontSet[0]);
                for (var j = 1; j < i; j++)
                {
                    newSet.Add(frontSet[j] + frontSet[j - 1]);
                }

                newSet.Add(frontSet[frontSet.Count - 1]);
                set.Add(newSet);
            }

            return set;
        }
    }
}