using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class ReorderList : AbstractExecuteModule
    {
        [MarkedItem(@"https://oj.leetcode.com/problems/Reorder-List/")]
        public override void Execute()
        {
            var order = Enumerable.Range(0, 11).ToList();
            GetReorderList(order).Dump();
        }

        private IEnumerable<int> GetReorderList(List<int> order)
        {
            var index = 0;
            while (index < (order.Count - 1) / 2)
            {
                order.Insert(index * 2 + 1, order[order.Count - 1]);
                order.RemoveAt(order.Count - 1);
                index++;
            }

            return order;
        }
    }
}