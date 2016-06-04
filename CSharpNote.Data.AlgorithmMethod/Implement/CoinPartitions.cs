using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class CoinPartitions : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            Console.WriteLine(CaculateCoinPartitions(5));
        }

        private int CaculateCoinPartitions(int total)
        {
            var sum = 0;
            for (var i = 1; i <= total; i++)
            {
                var leak = total - i;
                if (leak > 0)
                {
                    sum += CaculateCoinPartitions(leak);
                    continue;
                }

                if (leak == 0)
                {
                    return sum++;
                }
            }

            return sum;
        }
    }
}