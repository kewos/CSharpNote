using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class AmicableNumbers : AbstractExecuteModule
    {
        [AopTarget(@"https://projecteuler.net/problem=21")]
        public override void Execute()
        {
            var max = 10000;
            var sumSet = Enumerable.Range(2, max - 1)
                .Select(number => new
                {
                    Key = number,
                    Value = number.Factor()
                        .Where(factor => factor < number)
                        .Sum()
                })
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var element in sumSet.Where(set => (sumSet.ContainsKey(set.Value) && set.Key == sumSet[set.Value]))
                )
            {
                Console.WriteLine("index:{0} sum:{1}", element.Key, element.Value);
            }
        }
    }
}