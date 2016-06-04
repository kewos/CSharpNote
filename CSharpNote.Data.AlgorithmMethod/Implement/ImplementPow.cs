using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class ImplementPow : AbstractExecuteModule
    {
        [MarkedItem(@"https://oj.leetcode.com/problems/search-a-2d-matrix/")]
        public override void Execute()
        {
            Console.WriteLine(GetImplementPow(3, 3));
        }

        private double GetImplementPow(double x, int y)
        {
            if (y == 0)
                return 1;

            if (y == 1)
                return x;

            var temp = GetImplementPow(x, y / 2);
            if (y % 2 == 0)
                return temp * temp;

            return x * temp * temp;
        }
    }
}