using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //You are given an n x n 2D matrix representing an image.
    //Rotate the image by 90 degrees (clockwise).
    //Follow up:
    //Could you do this in-place?
    public class RotateImage : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/rotate-image/")]
        public override void Execute()
        {
            var matrix = new[,]
            {
                {1, 5, 5, 5, 5},
                {1, 5, 5, 5, 5},
                {1, 5, 5, 5, 5},
                {1, 5, 5, 5, 5},
                {1, 5, 5, 5, 5}
            };

            RotateDegree90(matrix);
        }

        private void RotateDegree90(int[,] array)
        {
            var result = new int[array.GetLength(1), array.GetLength(0)];
            for (var i = 0; i < array.GetLength(0); i++)
            {
                for (var j = 0; j < array.GetLength(1); j++)
                {
                    result[j, array.GetLength(0) - i - 1] = array[i, j];
                }
            }
        }
    }
}