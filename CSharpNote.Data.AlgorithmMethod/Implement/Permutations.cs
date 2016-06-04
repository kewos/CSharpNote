using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given a collection of numbers, return all possible permutations.
    //For example,
    //[1,2,3] have the following permutations:
    //[1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], and [3,2,1]
    public class Permutations : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/permutations/")]
        public override void Execute()
        {
            var elements = Enumerable.Range(1, 7).ToList();

            GetPermutations(elements, elements.Count).DumpMany();
        }

        private IEnumerable<List<int>> GetPermutations(List<int> elements, int level, List<int> sub = null)
        {
            var subSets = new List<List<int>>();
            if (level == 0)
                return new List<List<int>> {sub};

            if (sub == null)
                sub = new List<int>();

            foreach (var element in elements)
            {
                if (sub.Contains(element))
                    continue;

                var tmp = sub.ToList();
                tmp.Add(element);
                subSets.AddRange(GetPermutations(elements, level - 1, tmp));
            }

            return subSets;
        }
    }
}