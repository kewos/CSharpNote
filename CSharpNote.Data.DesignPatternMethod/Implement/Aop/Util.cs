using System;

namespace CSharpNote.Data.DesignPattern.Implement.Aop
{
    public static class Utils
    {
        public static Func<Type[], Type[], bool> typeArrayMatch = (x, y) =>
        {
            for (var i = 0; i < x.Length; ++i)
            {
                if (x[i] != y[i]) return false;
            }
            return true;
        };
    }
}