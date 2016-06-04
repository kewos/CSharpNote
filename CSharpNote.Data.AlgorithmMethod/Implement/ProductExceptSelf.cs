using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class ProductExceptSelf : AbstractExecuteModule
    {
        [MarkedItem("https://leetcode.com/problems/product-of-array-except-self/")]
        public override void Execute()
        {
            var set = new[] { 1, 1 };
            GetProductExceptSelf(set).Dump();
        }

        private int[] GetProductExceptSelf(int[] nums)
        {
            if (nums.Count() < 2)
                return null;

            var zeroCount = nums.Where(x => x == 0).Count();
            if (zeroCount >= 2)
                return nums.Select(x => 0).ToArray();

            var total = nums.Where(x => x != 0).Aggregate((a, b) => a * b);

            return zeroCount != 1
                ? nums.Select(x => total / x).ToArray()
                : nums.Select(x => x == 0 ? total : 0).ToArray();
        }
    }
}