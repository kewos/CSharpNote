using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given a sorted array and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
    //You may assume no duplicates in the array.
    //Here are few examples.
    //[1,3,5,6], 5 → 2
    //[1,3,5,6], 2 → 1
    //[1,3,5,6], 7 → 4
    //[1,3,5,6], 0 → 0
    public class SearchInsertPosition : AbstractExecuteModule
    {
        [MarkedItem(@"https://oj.leetcode.com/problems/search-insert-position/")]
        public override void Execute()
        {
            var testArray = new List<int> { 1, 3, 5, 6 };

            Console.WriteLine(GetSearchInsertPositionⅰ(testArray, 5));
        }

        private int GetSearchInsertPosition(List<int> array, int target)
        {
            var n = 0;
            while (n < array.Count())
            {
                if (target <= array[n]) 
                    return n;

                n++;
            }

            return n;
        }

        private int GetSearchInsertPositionⅰ(List<int> array, int target)
        {
            var low = 0;
            var height = array.Count - 1;

            if (target <= array[low])
                return low;

            if (target > array[height])
                return height + 1;

            while (low < height)
            {
                var mid = low + (height - low) / 2;
                if (target > array[mid])
                    low = mid + 1;
                else if (target < array[mid])
                    height = mid - 1;
                else
                    return mid;
            }

            return low;
        }
    }
}