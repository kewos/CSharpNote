using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:
    //Integers in each row are sorted from left to right.
    //The first integer of each row is greater than the last integer of the previous row.
    //For example,
    //Consider the following matrix:
    //  [1,   3,  5,  7],
    //  [10, 11, 16, 20],
    //  [23, 30, 34, 50]
    //Given target = 3, return true.
    public class SearchA2dMatrix : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/search-a-2d-matrix/")]
        public override void Execute()
        {
            var matrix = new int[3, 4] {{1, 3, 5, 7}, {10, 11, 16, 20}, {23, 30, 34, 50}};
            var target = 9;

            Console.WriteLine(GetSearchA2dMatrix(matrix, target));
        }

        private bool GetSearchA2dMatrix(int[,] matrix, int target)
        {
            var end = matrix.GetLength(0)*matrix.GetLength(1);
            var start = matrix.GetLength(1);
            while (start != end)
            {
                var x = start/matrix.GetLength(1);
                var y = start%matrix.GetLength(0);
                if (matrix[x, y] - target <= matrix[x - 1, y])
                    return false;

                start++;
            }

            return true;
        }
    }
}