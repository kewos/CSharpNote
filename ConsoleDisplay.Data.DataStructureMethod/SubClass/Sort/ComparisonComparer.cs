using System;
using System.Collections.Generic;

namespace ConsoleDisplay.Data.DataStructureMethod.SubClass
{
    public class ComparisonComparer<T> : IComparer<T>
    {
        private Comparison<T> comparsion;

        public ComparisonComparer(Comparison<T> comparsion)
        {
            this.comparsion = comparsion;
        }

        public Comparison<T> Comparsion
        {
            get
            {
                return comparsion;
            }
            set
            {
                comparsion = value;
            }
        }

        public int Compare(T x, T y)
        {
            return comparsion(x, y);
        }
    }
}
