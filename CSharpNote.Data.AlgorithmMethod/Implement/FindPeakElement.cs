using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// <summary>
    ///     context
    ///     尋找第一個峰項的引數
    ///     solution
    ///     爬山 坡度上升用peakIndex儲存位置下降回傳Index
    /// </summary>
    public class FindPeakElement : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            DoFindPeakElement(new[] {1, 2, 3, 1}).ToConsole();
        }

        public int DoFindPeakElement(int[] nums)
        {
            if (nums.Length < 1)
                return 0;

            var peakIndex = 0;
            for (var index = 0; index < nums.Length - 1; index++)
            {
                if (nums[index] < nums[index + 1])
                    peakIndex = index + 1;
                if (nums[index] > nums[index + 1])
                    return peakIndex;
            }

            return peakIndex;
        }
    }
}