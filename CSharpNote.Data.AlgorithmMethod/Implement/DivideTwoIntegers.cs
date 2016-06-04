using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class DivideTwoIntegers : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/divide-two-integers/")]
        public override void Execute()
        {
            //Divide two integers without using multiplication, division and mod operator.
            Console.WriteLine(GetDivideTwoIntegers(100, 33));
        }

        private int GetDivideTwoIntegers(int x, int y)
        {
            if (x == 0 || y == 0)
                return 0;

            var state = 1;
            if (!((x > 0 && y > 0) || (x < 0 && y < 0)))
                state = 1;

            var sum = 0;
            while ((x >= y))
            {
                x -= y;
                sum++;
            }

            return sum*state;
        }
    }
}