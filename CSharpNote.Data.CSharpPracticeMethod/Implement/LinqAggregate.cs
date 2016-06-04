using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class LinqAggregate : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            //get all element sum
            var sum = Enumerable.Range(1, 10).Aggregate((a, b) => a + b);
            Console.WriteLine(sum);

            var chars = new[] {"a", "b", "c", "d"};
            var csv = chars.Aggregate((a, b) => a + ',' + b);
            // Output a,b,c,d
            Console.WriteLine(csv);

            var multipliers = new[] {10, 20, 30, 40};
            var multiplied = multipliers.Aggregate(5, (a, b) => a*b);
            //Output 1200000 ((((5*10)*20)*30)*40)
            Console.WriteLine(multiplied);
        }
    }
}