using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class SummaryRanges : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            //https://leetcode.com/problems/summary-ranges/
            var nums = new[] {0, 1, 2, 4, 5, 7};

            GetSummaryRanges(nums).Dump();
        }

        private List<string> GetSummaryRanges(int[] nums)
        {
            if (nums == null || nums.Count() == 0)
                return new List<string>();

            var index = -1;
            var result = new List<string>();
            var temp = new List<int>();
            while (++index < nums.Count())
            {
                if (!temp.Any())
                {
                    temp.Add(nums[index]);
                    continue;
                }

                if (temp.Last() + 1 == nums[index])
                    temp.Add(nums[index]);
                else
                {
                    result.Add(ConvertToSummary(temp));
                    temp.Clear();
                    temp.Add(nums[index]);
                }
            }

            result.Add(ConvertToSummary(temp));

            return result.Where(x => x != string.Empty).ToList();
        }

        private string ConvertToSummary(List<int> temp)
        {
            if (temp == null && !temp.Any())
                return string.Empty;

            if (temp.First() == temp.Last())
                return temp.First().ToString();

            return string.Format("{0}->{1}", temp.First(), temp.Last());
        }
    }
}