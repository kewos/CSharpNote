using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class LengthOfLIS : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            DoLengthOfLIS(new[] {10, 9, 2, 5, 3, 7, 101, 18}).ToConsole();
        }

        public int DoLengthOfLIS(int[] nums)
        {
            var temp = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                var current = temp.Where(x => x.Key < num);
                if (!current.Any())
                {
                    temp[num] = temp.ContainsKey(num)
                        ? temp[num]
                        : 1;
                    continue;
                }
                var max = current.OrderByDescending(x => x.Value).First();
                temp = temp.Where(x => x.Key > max.Key).ToDictionary(x => x.Key, x => x.Value);
                temp[max.Key] = max.Value + 1;
            }

            return temp.Max(x => x.Value);
        }
    }
}