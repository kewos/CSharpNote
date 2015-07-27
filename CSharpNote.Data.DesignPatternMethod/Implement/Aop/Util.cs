using System;

namespace CSharpNote.Data.DesignPattern.Implement.Aop
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
