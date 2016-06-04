using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class QSort : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            var random = new Random();
            var set = Enumerable.Range(0, 10).OrderBy(x => random.Next());

            QuickSort(set).Dump();
        }

        private IEnumerable<int> QuickSort(IEnumerable<int> source)
        {
            var quickSort = source as IList<int> ?? source.ToList();
            if (!quickSort.Any())
                return quickSort;

            var pivot = quickSort.First();

            return QuickSort(quickSort.Where(n => n < pivot))
                .Concat(quickSort.Where(n => n == pivot))
                .Concat(QuickSort(quickSort.Where(n => n > pivot)));
        }
    }
}