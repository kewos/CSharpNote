using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// <summary>
    ///     context
    ///     三個元素加起來等於0
    ///     solution
    ///     使用三個指針 index1向右 index2於index1 +1 向右 index3最尾邊向左
    ///     當index2 > index3 index1 + 1
    ///     使用三個元素組成新的hashcode防重複組合進入
    /// </summary>
    public class ThreeSum : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            GetThreeSum(new[] {-2, 0, 1, 1, 2}).DumpMany();
        }

        private List<List<int>> GetThreeSum(int[] nums)
        {
            var result = new HashSet<List<int>>();
            if (nums.Length < 3)
                return result.ToList();

            Array.Sort(nums);
            for (var index1 = 0; index1 < nums.Length - 2; index1++)
            {
                var index2 = index1 + 1;
                var index3 = nums.Length - 1;
                while (index2 < index3)
                {
                    var sum = nums[index1] + nums[index2] + nums[index3];
                    if (sum == 0)
                    {
                        result.Add(new SumItem {nums[index1], nums[index2], nums[index3]});
                        index2++;
                        index3--;
                    }
                    else if (sum < 0)
                        index2++;
                    else
                        index3--;
                }
            }

            return result.ToList();
        }

        private List<List<int>> FourSum(int[] nums, int target)
        {
            var result = new HashSet<List<int>>();
            if (nums.Length < 4)
                return result.ToList();

            Array.Sort(nums);
            for (var index1 = 0; index1 < nums.Length - 3; index1++)
            {
                for (var index2 = index1 + 1; index2 < nums.Length - 2; index2++)
                {
                    var index3 = index2 + 1;
                    var index4 = nums.Length - 1;
                    while (index3 < index4)
                    {
                        var sum = nums[index1] + nums[index2] + nums[index3] + nums[index4];
                        if (sum == target)
                        {
                            result.Add(new SumItem {nums[index1], nums[index2], nums[index3], nums[index4]});
                            index3++;
                            index4--;
                        }
                        else if (sum < target)
                            index3++;
                        else
                            index4--;
                    }
                }
            }

            return result.ToList();
        }

        private class SumItem : List<int>
        {
            public override int GetHashCode()
            {
                unchecked
                {
                    return this.Aggregate(19, (current, item) => current*31 + item.GetHashCode());
                }
            }

            public override bool Equals(object obj)
            {
                var other = obj as SumItem;
                if (other == null)
                    return false;

                return this[0] == other[0] && this[1] == other[1] && this[2] == other[2];
            }
        }
    }
}