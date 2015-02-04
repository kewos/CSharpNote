﻿using System.Collections.Generic;

namespace ConsoleDisplay.Data.DataStructureMethod.SubClass.Sort
{
    public interface ISort<T>
    {
        IList<T> Sort(IList<T> list);
        IList<T> Sort(IList<T> list, SortOrder order);
    }
}
