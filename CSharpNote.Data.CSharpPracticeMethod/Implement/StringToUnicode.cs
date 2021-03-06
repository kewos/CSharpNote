using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class StringToUnicode : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            const int number = 100;
            Console.WriteLine("二進制:{0}", Convert.ToString(number, 2));
            Console.WriteLine("八進制:{0}", Convert.ToString(number, 8));
            Console.WriteLine("二進制:{0}", Convert.ToString(number, 10));
            Console.WriteLine("十六進制:{0}", Convert.ToString(number, 16));

            Console.WriteLine("十六進制:{0}", number.ToString("X"));
            Console.WriteLine("長度4 十六進制:{0}", number.ToString("X4"));
        }
    }
}