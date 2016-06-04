using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class NumberMind : AbstractExecuteModule
    {
        [MarkedItem(@"https://projecteuler.net/problem=185")]
        public override void Execute()
        {
            var dictionary = new Dictionary<int, int>
            {
                {90342, 2},
                {70794, 0},
                {39458, 2},
                {34109, 1},
                {51545, 2},
                {12531, 1}
            };

            GetNumberMind(5, dictionary).ToConsole();
        }

        private int GetNumberMind(int digit, Dictionary<int, int> dictionary)
        {
            var elements = Enumerable.Range((int)Math.Pow(10, digit - 1),
                (int)Math.Pow(10, digit) - (int)Math.Pow(10, digit - 1));

            return elements.FirstOrDefault(element =>
                dictionary.All((key, keypair) =>
                {
                    var compareItem1 = keypair.Key.ToString();
                    var compareItem2 = element.ToString();
                    var times = keypair.Value;
                    var count = 0;
                    for (var index = 0; index < digit; index++)
                    {
                        if (compareItem1[index] == compareItem2[index])
                            count++;
                        if (count > times)
                            return false;
                    }

                    return (count == times);
                }));
        }
    }
}