using System.Collections.Generic;

namespace CSharpNote.Common.Extensions
{
    public static class IntExtensions
    {
        public static IEnumerable<int> DecomposeNoSignDigit(this int target)
        {
            while (target != 0)
            {
                yield return target%10;
                target /= 10;
            }
        }
    }
}