using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given two sorted integer arrays A and B, merge B into A as one sorted array.
    //Note:
    //You may assume that A has enough space (size that is greater or equal to m + n) to hold additional elements from B. The number of elements initialized in A and B are m and n respectively.
    public class MergeSortedArray : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/merge-sorted-array/")]
        public override void Execute()
        {
            var list1 = new List<int> {1, 1, 1, 5, 6, 7};
            var list2 = new List<int> {2, 3, 7, 9};

            GetMergeSortedArray(list1, list2).Dump();
        }

        private List<int> GetMergeSortedArray(List<int> list1, List<int> list2)
        {
            var p1 = 0;
            var p2 = 0;
            while (p2 < list2.Count)
            {
                while (p1 < list1.Count && list1[p1++] < list2[p2]) ;

                list1.Insert(p1, list2[p2]);
                p2++;
            }

            return list1;
        }
    }
}