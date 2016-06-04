using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// <summary>
    ///     context
    ///     搜尋target是否有在matrix當中
    ///     solution
    ///     二元搜尋row直到第一個引數大於target
    /// </summary>
    public class SearchMatrix : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var matrix = new[,]
            {
                {1, 4, 7, 11, 15, 60},
                {2, 5, 8, 12, 19, 61},
                {3, 6, 9, 16, 22, 62},
                {10, 13, 14, 17, 24, 63},
                {18, 21, 23, 26, 30, 64}
            };

            GetSearchMatrix(matrix, 23).ToConsole();
        }

        private bool GetSearchMatrix(int[,] matrix, int target)
        {
            for (var x = 0; x < matrix.GetLength(0); x++)
            {
                if (matrix[x, 0] > target)
                    return false;

                if (BinarySearch(matrix, x, target))
                    return true;
            }

            return false;
        }

        private bool BinarySearch(int[,] matrix, int x, int target)
        {
            var right = matrix.GetLength(1) - 1;
            var left = 0;

            while (left <= right)
            {
                var middle = (right + left)/2;

                if (matrix[x, middle] == target)
                    return true;

                if (matrix[x, middle] > target)
                    right = middle - 1;
                else
                    left = middle + 1;
            }

            return false;
        }
    }
}