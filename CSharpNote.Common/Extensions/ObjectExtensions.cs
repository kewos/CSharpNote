using System;

namespace CSharpNote.Common.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        ///     顯示於Console
        /// </summary>
        public static string ToConsole(this object obj, string prefix = "", string suffix = "")
        {
            var str = string.Format("{1} {0} {2}", obj ?? "null", prefix, suffix);
            Console.WriteLine(str);
            return str;
        }
    }
}