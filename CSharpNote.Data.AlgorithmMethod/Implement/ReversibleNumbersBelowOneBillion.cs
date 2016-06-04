using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class ReversibleNumbersBelowOneBillion : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var sum = 0;
            foreach (var number in Enumerable.Range(1, 900))
            {
                if (number%10 == 0)
                    continue;

                var reverseNumber = GetReverseNumber(number);
                if (IsReverseNumber(reverseNumber))
                    sum++;
            }

            Console.WriteLine(sum);
        }

        private bool IsReverseNumber(int number)
        {
            return number == GetReverseNumber(number);
        }

        private int GetReverseNumber(int number)
        {
            return int.Parse(Reverse(number.ToString()));
        }

        private string Reverse(string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }
    }
}