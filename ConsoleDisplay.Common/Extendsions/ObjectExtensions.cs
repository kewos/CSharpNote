using System;

namespace ConsoleDisplay.Common.Extendsions
{
    public static class ObjectExtensions
    {
        public static void ToConsole(this object obj, string prefix= "", string suffix = "")
        {
            Console.WriteLine("{1}{0}{2}", obj ?? "null", prefix, suffix);
        }
    }
}
