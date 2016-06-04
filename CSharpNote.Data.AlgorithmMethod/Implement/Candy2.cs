using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class Candy2 : AbstractExecuteModule
    {
        [AopTarget("https://leetcode.com/problems/candy/")]
        public override void Execute()
        {
            var ratings = new[] {2, 1, 9, 2, 3, 34, 1};

            GetCandy2(ratings).ToConsole();
        }

        public int GetCandy2(int[] ratings)
        {
            if (!ratings.Any())
                return 0;

            var candy = Enumerable.Repeat(1, ratings.Length).ToList();
            var peak = 0;

            for (var index = 0; index < ratings.Length - 1; index++)
            {
                if (ratings[index] < ratings[index + 1])
                {
                    candy[index + 1] = candy[index] + 1;
                    peak = index + 1;
                    continue;
                }

                if (ratings[index] > ratings[index + 1]
                    && candy[index] <= candy[index + 1])
                {
                    for (var addIndex = peak; addIndex <= index; addIndex++)
                        candy[addIndex]++;

                    continue;
                }

                if (ratings[index] != ratings[index + 1])
                    continue;

                var max = Math.Max(candy[index], candy[index + 1]);
                candy[index] = max;
                candy[index + 1] = max;
            }

            return candy.Sum();
        }
    }
}