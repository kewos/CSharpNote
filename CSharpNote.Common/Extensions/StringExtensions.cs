using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpNote.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        ///     是否迴文
        /// </summary>
        public static bool IsPalindrome(this string @string)
        {
            var mid = @string.Length/2;

            for (var i = 0; i < mid; i++)
            {
                if (@string[i] != @string[@string.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     格式化字串
        /// </summary>
        public static string Format(this string format, params object[] items)
        {
            return string.Format(format, items);
        }

        /// <summary>
        ///     是否為空或Empty
        /// </summary>
        public static bool IsNullOrEmpty(this string target)
        {
            return string.IsNullOrEmpty(target);
        }

        /// <summary>
        ///     排除字元
        /// </summary>
        public static string Except(this string target, string except)
        {
            return target.Replace(except, "");
        }

        /// <summary>
        ///     分解字元成數字列
        /// </summary>
        public static IList<int> DecomposeDigit(string source)
        {
            return source.Select(@char => (int) char.GetNumericValue(@char)).ToList();
        }

        /// <summary>
        ///     反轉字串
        /// </summary>
        public static string Reverse(this string source)
        {
            var charArray = source.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}