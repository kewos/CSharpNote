using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class FindKthLargest : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var nums = Enumerable.Range(1, 1).Shuffle().ToArray();
            var k = 1;

            GetFindKthLargest(nums, k).ToConsole();
        }

        private int GetFindKthLargest(int[] nums, int k)
        {
            return nums.OrderByDescending(x => x).Skip(k - 1).First();
        }
    }
}