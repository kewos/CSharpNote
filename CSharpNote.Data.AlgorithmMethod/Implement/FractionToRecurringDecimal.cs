using System;
using System.Collections.Generic;
using System.Text;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given two integers representing the numerator and denominator of a fraction, return the fraction in string format.
    //If the fractional part is repeating, enclose the repeating part in parentheses.
    //For example,
    //Given numerator = 1, denominator = 2, return "0.5".
    //Given numerator = 2, denominator = 1, return "2".
    //Given numerator = 2, denominator = 3, return "0.(6)".
    public class FractionToRecurringDecimal : AbstractExecuteModule
    {
        [MarkedItem(@"https://oj.leetcode.com/problems/fraction-to-recurring-decimal/")]
        public override void Execute()
        {
            Console.WriteLine(GetFractionToRecurringDecimal(1, 2));
            Console.WriteLine(GetFractionToRecurringDecimal(2, 1));
            Console.WriteLine(GetFractionToRecurringDecimal(2, 3));
        }

        private string GetFractionToRecurringDecimal(int numerator, int denominator)
        {
            if (numerator == 0)
                return "0";

            var result = new StringBuilder();

            if (numerator < 0 ^ denominator < 0)
                result.Append("-");

            numerator = Math.Abs(numerator);
            denominator = Math.Abs(denominator);

            result.Append(numerator / denominator);
            if (numerator % denominator == 0)
                return result.ToString();

            result.Append(".");
            for (var dic = new Dictionary<int, int>(); numerator > 0; numerator %= denominator)
            {
                if (dic.ContainsKey(numerator))
                {
                    result = result.Insert(dic[numerator], "(");
                    result.Append(")");
                    break;
                }

                dic.Add(numerator, result.Length);
                numerator *= 10;
                result.Append(numerator / denominator);
            }

            return result.ToString();
        }
    }
}