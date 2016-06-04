using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //given two integers n and k, return all possible combinations of k numbers out of 1 ... n.
    //for example,
    //if n = 4 and k = 2, a solution is
    public class Combinations : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/combinations/", true)]
        public override void Execute()
        {
            var set = new List<List<int>>();
            var n = 4;
            var k = 2;
            var pass = n - k;
            GetCombinations(n, k, pass, new List<int>(), set);

            set.DumpMany();
        }

        private void GetCombinations(int n, int k, int pass, List<int> subset, List<List<int>> set)
        {
            if (k <= 0)
            {
                set.Add(subset);
                return;
            }

            if (pass > 0)
            {
                GetCombinations(n - 1, k, pass - 1, subset.ToList(), set);
            }

            var subSet1 = subset.ToList();
            subSet1.Add(n);
            GetCombinations(n - 1, k - 1, pass, subSet1, set);
        }
    }
}