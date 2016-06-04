using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/insert-interval/
    //Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).
    //You may assume that the intervals were initially sorted according to their start times.
    //Example 1:
    //Given intervals [1,3],[6,9], insert and merge [2,5] in as [1,5],[6,9].
    //Example 2:
    //Given [1,2],[3,5],[6,7],[8,10],[12,16], insert and merge [4,9] in as [1,2],[3,10],[12,16].
    //This is because the new interval [4,9] overlaps with [3,5],[6,7],[8,10].
    public class InsertInterval : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var intSet = new List<List<int>>
            {
                new List<int> {1, 2},
                new List<int> {3, 5},
                new List<int> {6, 7},
                new List<int> {8, 10},
                new List<int> {12, 16}
            };
            var newInterval = new List<int> {1, 100};

            Insert(intSet, newInterval).ForEach(set => Console.WriteLine("[{0},{1}]", set[0], set[1]));
        }

        private List<List<int>> Insert(List<List<int>> intSet, List<int> interval)
        {
            intSet.Add(interval);
            var list = intSet.Where(set => !(interval[0] < set[0] && interval[1] > set[1]));
            var start = list.Where(set => interval[0] <= set[1] && interval[1] >= set[1]).Min(set => set[0]);
            var end = list.Where(set => interval[1] >= set[0] && interval[0] <= set[0]).Max(set => set[1]);
            var newInterval = new List<int> {start, end};
            var need = list.Where(set => set[1] <= interval[0] || set[0] >= interval[1]).ToList();

            need.Add(newInterval);

            return need;
        }
    }
}