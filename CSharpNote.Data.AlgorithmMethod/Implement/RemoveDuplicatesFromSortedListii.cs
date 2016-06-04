using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class RemoveDuplicatesFromSortedListii : AbstractExecuteModule
    {
        [MarkedItem(@"https://oj.leetcode.com/problems/remove-duplicates-from-sorted-list-ii/")]
        public override void Execute()
        {
            var list = new List<int> { 1, 1, 1, 1, 2, 5, 6, 9, 88, 88, 99, 99, 99, 100 };

            GetRemoveDuplicatesFromSortedListii(list).Dump();
        }

        private IEnumerable<int> GetRemoveDuplicatesFromSortedListii(List<int> list)
        {
            var i = 1;
            var state = false;
            while (i < list.Count)
            {
                if (list[i - 1] == list[i])
                {
                    list.RemoveAt(i - 1);
                    state = true;
                    continue;
                }

                if (state)
                {
                    list.RemoveAt(i - 1);
                    state = false;
                    continue;
                }

                i++;
            }

            return list;
        }
    }
}