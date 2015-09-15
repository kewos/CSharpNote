
using System;

namespace CSharpNote.Common.Utility
{
    public static class GenericUtility
    {
        public static bool NoOverlap<T>(T source1, T source2, T source3, T source4)
            where T : IComparable<T>
        {
            if (source1.CompareTo(source2) >= 0 || source3.CompareTo(source4) >= 0)
                return false;

            return source2.CompareTo(source3) < 0 || source4.CompareTo(source1) < 0;
        }
    }
}
