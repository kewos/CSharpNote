using System;
using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class IsUgly : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            DoIsUgly(10).ToConsole();
        }

        public bool DoIsUgly(int num)
        {
            if (num < 1)
                return false;
            if (num < 7)
                return true;

            var factors = new List<int> { 2, 3, 5 };
            var index = 0;
            while (num >= 7)
            {
                if (index == factors.Count)
                    return false;

                if (num % factors[index] == 0)
                {
                    num /= factors[index];
                    continue;
                }

                index++;
            }

            return true;
        }

        public int NthUglyNumber(int n)
        {
            if (n < 0)
                throw new Exception();

            if (n <= 6)
                return n;

            var num = 7;
            var current = 6;
            while (current != n)
            {
                if (DoIsUgly(num))
                    current++;
                num++;
            }

            return num;
        }
    }
}