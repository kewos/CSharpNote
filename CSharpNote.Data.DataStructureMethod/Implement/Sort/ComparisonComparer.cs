using System;
using System.Collections.Generic;

namespace CSharpNote.Data.DataStructure.Implement.Sort
{
    public class ComparisonComparer<T> : IComparer<T>
    {
        public ComparisonComparer(Comparison<T> comparsion)
        {
            this.Comparsion = comparsion;
        }

        public Comparison<T> Comparsion { get; set; }

        public int Compare(T x, T y)
        {
            return Comparsion(x, y);
        }
    }
}