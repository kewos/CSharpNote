using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class PermutationSequence : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/permutation-sequence/")]
        public override void Execute()
        {
            GetPermutationSequence(3).DumpMany();
        }

        private List<List<int>> GetPermutationSequence(int n)
        {
            var containElement = Enumerable.Range(1, n).ToList();
            var sets = containElement.Select(elements => new List<int> {elements}).ToList();
            containElement.Select(elements => new List<int> {elements});
            for (var i = 1; i < n; i++)
            {
                var temp = new List<List<int>>();
                sets.ForEach(set =>
                {
                    foreach (var element in containElement.Where(elements => !set.Contains(elements)))
                    {
                        var sub = set.ToList();
                        sub.Add(element);
                        temp.Add(sub);
                    }
                });

                sets = temp;
            }

            return sets;
        }
    }
}