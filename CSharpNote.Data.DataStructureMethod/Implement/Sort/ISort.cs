using System.Collections.Generic;

namespace CSharpNote.Data.DataStructureMethod.Implement.Sort
{
    public interface ISort<T>
    {
        IList<T> Sort(IList<T> list);
        IList<T> Sort(IList<T> list, SortOrder order);
    }
}
