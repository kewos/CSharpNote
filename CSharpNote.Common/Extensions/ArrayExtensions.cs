using System;

namespace CSharpNote.Common.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        ///     取得子字串
        /// </summary>
        public static T[] SubArray<T>(this T[] source, int index, int length)
        {
            var result = new T[length];
            Array.Copy(source, index, result, 0, length);
            return result;
        }
    }
}