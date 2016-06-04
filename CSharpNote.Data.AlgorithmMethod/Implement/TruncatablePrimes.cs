using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class TruncatablePrimes : AbstractExecuteModule
    {
        [MarkedItem(@"https://projecteuler.net/problem=37")]
        public override void Execute()
        {
            var valid = 3797;
            var validString = valid.ToString();
            var group = new List<int>();
            for (var index = 0; index < validString.Length; index++)
            {
                var sub1 = validString.Substring(validString.Length - index - 1, index + 1);
                var sub2 = validString.Substring(index, validString.Length - index);

                int value1;
                if (int.TryParse(sub1, out value1))
                    group.Add(value1);

                int value2;
                if (int.TryParse(sub2, out value2))
                    group.Add(value2);
            }

            Console.WriteLine("All Primes{0}", group.All(i => i.IsPrime()));
        }
    }
}