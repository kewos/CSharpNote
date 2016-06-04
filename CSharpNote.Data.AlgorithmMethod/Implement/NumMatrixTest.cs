using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class NumMatrixTest : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var matrix = new[,]
            {
                {3, 0, 1, 4, 2},
                {5, 6, 3, 2, 1},
                {1, 2, 0, 1, 5},
                {4, 1, 0, 1, 7},
                {1, 0, 3, 0, 5}
            };

            var numMatrix = new NumMatrix(matrix);

            numMatrix.SumRegion(2, 1, 4, 3).ToConsole();
            numMatrix.SumRegion(1, 1, 2, 2).ToConsole();
            numMatrix.SumRegion(1, 2, 2, 4).ToConsole();
        }

        public class NumMatrix
        {
            private readonly Dictionary<string, int> hash = new Dictionary<string, int>();
            private readonly int[,] matrix;

            public NumMatrix(int[,] matrix)
            {
                this.matrix = matrix;
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                if (row1 >= row2 || col1 >= col2)
                    return default(int);

                var sum = 0;
                for (var row = row1; row <= row2; row++)
                {
                    var hashCode = string.Format("{0}#{1}#{2}#{3}", row, col1, row, col1);
                    if (hash.ContainsKey(hashCode))
                    {
                        sum += hash[hashCode];
                        continue;
                    }

                    var columnSum = 0;
                    for (var col = col1; col <= col2; col++)
                    {
                        columnSum += matrix[row, col];
                    }

                    sum += columnSum;
                }

                return sum;
            }
        }
    }
}