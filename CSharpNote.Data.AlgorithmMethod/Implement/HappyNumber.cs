using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class HappyNumber : AbstractExecuteModule
    {
        [MarkedItem("https://leetcode.com/problems/happy-number/")]
        public override void Execute()
        {
            IsHappy(7).ToConsole();

            IsHappy(100).ToConsole();
        }

        private bool IsHappy(int number)
        {
            if (number == 0)
                return false;

            if (number == 1)
                return true;

            var hashSet = new HashSet<int>();
            while (true)
            {
                number = number.DecomposeNoSignDigit().Sum(digit => digit * digit);
                if (number == 1)
                    return true;

                if (hashSet.Contains(number))
                    return false;

                hashSet.Add(number);
            }
        }
    }
}