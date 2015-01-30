using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplay.Data.DataStructureMethod.SubClass
{
    public interface ISort<T>
    {
        IList<T> Sort(IList<T> list);
        IList<T> Sort(IList<T> list, SortOrder order);
    }
}
