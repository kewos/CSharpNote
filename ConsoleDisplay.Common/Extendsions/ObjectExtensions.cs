using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplay
{
    public static class ObjectExtensions
    {
        public static void ToConsole(this object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
