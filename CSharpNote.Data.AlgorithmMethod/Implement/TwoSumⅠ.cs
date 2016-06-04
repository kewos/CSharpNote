using System;
using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// <summary>
    ///     context
    ///     兩個數加起來等於target
    ///     solution
    ///     用字典記錄target - num 及 num 去做mapping
    /// </summary>
    public class TwoSumⅠ : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            GetTwoSumⅠ(new[] { 3, 2, 4 }, 6).Dump();
        }

        private int[] GetTwoSumⅠ(int[] nums, int target)
        {
            var length = nums.Length;
            var dictionary = new Dictionary<int, int>();
            for (var i = 0; i < length; i++)
            {
                var num = nums[i];
                if (dictionary.ContainsKey(num))
                    return new[] { dictionary[num] + 1, i + 1 };

                dictionary[target - num] = i;
            }

            throw new ArgumentException("Invalid argument.");
        }
    }
}