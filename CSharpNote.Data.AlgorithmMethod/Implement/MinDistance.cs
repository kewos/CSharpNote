using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class MinDistance : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            var word1 = "aaaaa";
            var word2 = "aaa";

            GetMinDistance(word1, word2).ToConsole();
        }

        private int GetMinDistance(string word1, string word2)
        {
            var matrix = new int[word2.Length + 1, word1.Length + 1];
            matrix[0, 0] = 0;

            for (var i = 1; i <= word1.Length; i++)
                matrix[0, i] = i;

            for (var i = 1; i <= word2.Length; i++)
                matrix[i, 0] = i;

            for (var i = 1; i <= word2.Length; i++)
            {
                for (var j = 1; j <= word1.Length; j++)
                {
                    var min = Math.Min(matrix[i - 1, j - 1] + (word1[j - 1] == word2[i - 1] ? 0 : 1),
                        matrix[i - 1, j] + 1);
                    min = Math.Min(min, matrix[i, j - 1] + 1);

                    matrix[i, j] = min;
                }
            }

            return matrix[word2.Length, word1.Length];
        }
    }
}