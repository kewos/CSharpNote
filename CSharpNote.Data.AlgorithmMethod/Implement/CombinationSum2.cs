using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// <summary>
    ///     context
    ///     存重複數字列出可組成target的所有可能
    ///     solution
    ///     遞迴求解
    /// </summary>
    public class CombinationSum2 : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var result = GetCombinationSum2(new[] {1, 1}, 1);
            result.DumpMany();
        }

        private List<List<int>> GetCombinationSum2(int[] candidates, int target)
        {
            candidates = candidates.Where(x => x <= target).OrderBy(x => x).ToArray();
            var result = new List<List<int>>();
            GetCombinationSum2(candidates, target, new List<int>(), result);

            return result.Select(item => item.ToList()).ToList();
        }

        private void GetCombinationSum2(int[] candidates, int target, List<int> currentItems, List<List<int>> result,
            int candidateIndex = 0)
        {
            if (target == 0)
            {
                result.Add(currentItems);

                return;
            }

            if (target < 0 || candidateIndex >= candidates.Length || candidateIndex < 0)
                return;

            var preNum = int.MinValue;
            for (var index = candidateIndex; index < candidates.Length; index++)
            {
                var curNum = candidates[index];
                if (preNum == curNum)
                    continue;

                var items = currentItems.ToList();
                items.Add(candidates[index]);
                preNum = curNum;

                GetCombinationSum2(candidates, target - candidates[index], items, result, index + 1);
            }
        }
    }
}