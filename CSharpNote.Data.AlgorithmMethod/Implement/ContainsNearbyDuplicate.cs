using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class ContainsNearbyDuplicate : AbstractExecuteModule
    {
        [AopTarget("https://leetcode.com/problems/contains-duplicate-ii/")]
        public override void Execute()
        {
        }

        private bool GetContainsNearbyDuplicate(int[] nums, int k)
        {
            if (nums.Length < 2)
                return false;

            var dic = new Dictionary<int, HashSet<int>>();
            for (var index = 0; index < nums.Length; index++)
            {
                var num = nums[index];
                if (!dic.ContainsKey(num))
                {
                    dic.Add(num, new HashSet<int> {index});
                    continue;
                }

                var hashSet = dic[num];
                if (hashSet.Any(x => index - x <= k))
                    return true;

                hashSet.Add(index);
            }

            return false;
        }
    }
}