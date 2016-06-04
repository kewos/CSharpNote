using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/triangle/
    //Given a triangle, find the minimum path sum from top to bottom. Each step you may move to adjacent numbers on the row below.
    //For example, given the following triangle
    //[
    //     [2],
    //    [3,4],
    //   [6,5,7],
    //  [4,1,8,3]
    //]
    //The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).
    //Note:
    //Bonus point if you are able to do this using only O(n) extra space, where n is the total number of rows in the triangle.
    public class Triangle : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            

            var triangle = new List<List<int>>
            {
                new List<int> {2},
                new List<int> {3, 4},
                new List<int> {6, 5, 7},
                new List<int> {4, 1, 8, 3}
            };
            var level = 0;
            var index = 0;

            Console.WriteLine(GetMinValueByTrianglePath(triangle, level, index).Min(n => n.Sum(x => x)));
        }

        private List<List<int>> GetMinValueByTrianglePath(List<List<int>> triangle, int level, int index)
        {
            if (level + 1 >= triangle.Count)
                return new List<List<int>> { new List<int> { triangle[level][index] } };

            var leftValue = GetMinValueByTrianglePath(triangle, level + 1, index);
            var righttValue = GetMinValueByTrianglePath(triangle, level + 1, index + 1);

            leftValue.AddRange(righttValue);
            leftValue.ForEach(n => n.Add(triangle[level][index]));

            return leftValue;
        }
    }
}