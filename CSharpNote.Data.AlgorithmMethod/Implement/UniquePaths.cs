using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/unique-paths/
    //A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
    //The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below)
    //How many possible unique paths are there?
    //Above is a 3 x 7 grid. How many possible unique paths are there?
    //Note: m and n will be at most 100.
    public class UniquePaths : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var arrayX = 10;
            var arrayY = 9;
            var allStep = arrayX + arrayY - 2;
            var goDown = arrayX - 1;
            double res = 1;
            for (var step = 1; step <= goDown; step++)
            {
                var goRight = allStep - goDown;
                res = res*(goRight + step)/step;
            }

            Console.WriteLine(res);
        }
    }
}