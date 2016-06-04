using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Follow up for "Remove Duplicates":
    //What if duplicates are allowed at most twice?
    //For example,
    //Given sorted array A = [1,1,1,2,2,3],
    //Your function should return length = 5, and A is now [1,1,2,2,3].
    public class RemoveDuplicatesFromSortedArray¢º : AbstractExecuteModule
    {
        [MarkedItem(@"https://oj.leetcode.com/problems/remove-duplicates-from-sorted-array-ii/")]
        public override void Execute()
        {
            var elements = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 3, 3 };

            Console.WriteLine(GetRemoveDuplicatesFromSortedArray¢º(elements));
        }

        private int GetRemoveDuplicatesFromSortedArray¢º(List<int> elements)
        {
            if (elements.Count() <= 2)
                return elements.Count();

            for (var i = elements.Count - 1; i >= 2; i--)
            {
                if (elements[i] == elements[i - 2]) elements.RemoveAt(i);
            }

            return elements.Count();
        }
    }
}