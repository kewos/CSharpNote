using System;

namespace CSharpNote.Common.Extendsions
{
    public static class ObjectExtensions
    {
        public static string ToConsole(this object obj, string prefix= "", string suffix = "")
        {
            var str = string.Format("{1} {0} {2}", obj ?? "null", prefix, suffix);
            Console.WriteLine(str);
            return str;
        }
    }
}
