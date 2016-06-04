using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class MinimumSizeSubarraySum : AbstractExecuteModule
    {
        [MarkedItem("https://leetcode.com/problems/minimum-size-subarray-sum/")]
        public override void Execute()
        {
            var elements = new[] { 2, 3, 1, 2, 4, 3 };
            var solution = 7;

            GetMinimumSizeSubarraySum(solution, elements).ToConsole();
        }

        public int GetMinimumSizeSubarraySum(int solution, int[] elements)
        {
            var gap = 0;
            var length = elements.Length;

            while (++gap <= length)
            {
                var tail = length - gap + 1;
                var subArray = Enumerable.Range(0, tail)
                    .Select(start => elements.SubArray(start, gap));

                if (subArray.Any(array => array.Sum() >= solution))
                    return gap;
            }

            return 0;
        }
    }
}