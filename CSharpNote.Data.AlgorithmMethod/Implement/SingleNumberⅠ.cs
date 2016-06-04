using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class SingleNumber¢¹ : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            var nums = new[] { 1, 1, 2, 2, 10, 5, 10, 3, 3, 4, 4 };

            GetSingleNumber¢¹(nums).ToConsole();
        }

        private unsafe int GetSingleNumber¢¹(int[] nums)
        {
            fixed (int* pNums = nums)
            {
                for (var i = 0; i < nums.Count() - 1; i++)
                {
                    *(pNums + i + 1) ^= *(pNums + i);
                }

                return nums[nums.Count() - 1];
            }
        }
    }
}