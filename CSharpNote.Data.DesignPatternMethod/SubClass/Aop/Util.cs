using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.Aop
{
    public static class Utils
    {
        public static Func<Type[], Type[], bool> TypeArrayMatch = (x, y) =>
        {
            for (int i = 0; i < x.Length; ++i)
            {
                if (x[i] != y[i]) return false;
            }
            return true;
        };
    }
}
