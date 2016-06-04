using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given a sorted linked list, delete all duplicates such that each element appear only once.
    //For example,
    //Given 1->1->2, return 1->2.
    //Given 1->1->2->3->3, return 1->2->3.
    public class RemoveDuplicatesfromSortedList : AbstractExecuteModule
    {
        [MarkedItem(@"https://oj.leetcode.com/problems/remove-duplicates-from-sorted-list/")]
        public override void Execute()
        {
            
            var array = new List<int> { 1, 1, 2, 3, 3 };
            GetRemoveDuplicatesfromSortedList(array);
            array.Dump();
        }

        private void GetRemoveDuplicatesfromSortedList(List<int> array)
        {
            var index = 0;
            while (index < array.Count() - 1)
            {
                while (index + 1 < array.Count && array[index] == array[index + 1])
                {
                    array.RemoveAt(index + 1);
                }

                index++;
            }
        }
    }
}