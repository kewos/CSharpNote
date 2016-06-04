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
    ///     每個candidates可以重複加起來等於target
    ///     solution
    ///     遞迴求解
    /// </summary>
    public class CombinationSum : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var result = GetCombinationSum(new[] {2, 3, 6, 7}, 7);
            result.DumpMany();
        }

        private List<List<int>> GetCombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            return GetCombinationSum(candidates, target, new List<int>()).ToList();
        }

        private IEnumerable<List<int>> GetCombinationSum(int[] candidates, int target, IEnumerable<int> current,
            int candidateIndex = 0)
        {
            var enumerable = current as IList<int> ?? current.ToList();
            if (enumerable.Sum() == target)
                return new List<List<int>> {enumerable.ToList()};

            if (enumerable.Sum() > target || candidateIndex >= candidates.Length)
                return null;

            var result = new List<List<int>>();
            for (var index = candidateIndex; index < candidates.Length; index++)
            {
                var items = enumerable.ToList();
                items.Add(candidates[index]);

                var collection = GetCombinationSum(candidates, target, items, index + 1);
                if (collection != null && collection.Any())
                    result.AddRange(collection);
            }

            return result;
        }
    }
}