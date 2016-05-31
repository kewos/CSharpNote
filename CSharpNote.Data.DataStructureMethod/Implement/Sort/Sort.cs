using System.Collections.Generic;

namespace CSharpNote.Data.DataStructure.Implement.Sort
{
    public abstract class Sorts<T> : ISort<T>
    {
        public IList<T> Sort(IList<T> list)
        {
            return Sort(list, SortOrder.Ascending);
        }

        public abstract IList<T> Sort(IList<T> list, SortOrder order);
    }
}