using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// Suppose a sorted array is rotated at some pivot unknown to you beforehand.
    /// (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
    /// Find the minimum element.
    /// You may assume no duplicate exists in the array.
    public class FindMinimumInRotatedSortedArray : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var max = new List<int>();
            var sortArray = new List<int> {0, 1, 2, 4, 5, 6, 7};

            for (var i = 0; i < sortArray.Count; i++)
            {
                if (sortArray[0] != 0)
                {
                    max.Add(IntArrayToInt(sortArray));
                }

                sortArray.Add(sortArray[0]);
                sortArray.Remove(sortArray[0]);
            }

            Console.WriteLine(max.Min());
        }

        private int IntArrayToInt(IReadOnlyList<int> sortArray)
        {
            return
                sortArray.Select((t, i) => sortArray.Count - i - 1)
                    .Select((term, i) => sortArray[term]*(int) Math.Pow(10, i))
                    .Sum();
        }
    }
}