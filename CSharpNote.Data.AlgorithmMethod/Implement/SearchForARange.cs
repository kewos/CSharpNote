using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given a sorted array of integers, find the starting and ending position of a given target value.
    //Your algorithm's runtime complexity must be in the order of O(log n).
    //If the target is not found in the array, return [-1, -1].
    //For example,
    //Given [5, 7, 7, 8, 8, 10] and target value 8,
    //return [3, 4].
    public class SearchForARange : AbstractExecuteModule
    {
        [MarkedItem(@"https://oj.leetcode.com/problems/search-for-a-range/")]
        public override void Execute()
        {
            var search = new List<int> { 5, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 10, 10 };
            var target = 8;

            GetSearchForARange(search, target).Dump();
        }

        private List<int> GetSearchForARange(List<int> search, int target)
        {
            var index = SearchIndex(search, target, 0, search.Count - 1);
            var result = new List<int> { index, index };

            if (index == -1) return result;

            var right = index;
            while ((right = SearchIndex(search, target, 0, --right)) != -1)
                result[0] = right;

            var left = index;
            while ((left = SearchIndex(search, target, ++left, search.Count - 1)) != -1)
                result[1] = left;

            return result;
        }

        /// <summary>
        ///     binary search
        /// </summary>
        /// <param name="search">search list</param>
        /// <param name="target">search target</param>
        /// <param name="start">start postion</param>
        /// <param name="end">end postion</param>
        /// <returns>IndexPosition</returns>
        private int SearchIndex(List<int> search, int target, int start, int end)
        {
            while (start <= end)
            {
                var middle = start + (end - start) / 2;
                if (search[middle] > target)
                    end = middle - 1;

                if (search[middle] < target)
                    start = middle + 1;

                if (search[middle] == target)
                    return middle;
            }

            return -1;
        }
    }
}