using System;
using System.Collections.Generic;

namespace ConsoleDisplay.Data.DataStructureMethod.SubClass.Sort
{
    public interface IComparisonSorter<T>
    {
        void Sort(IList<T> list, IComparer<T> comparer);
        void Sort(IList<T> list, Comparison<T> comparison); 
    }
}
