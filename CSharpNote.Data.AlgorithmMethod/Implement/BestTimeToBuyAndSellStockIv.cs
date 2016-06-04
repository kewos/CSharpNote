using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class BestTimeToBuyAndSellStockIv : AbstractExecuteModule
    {
        [AopTarget("https://oj.leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/")]
        public override void Execute()
        {
            var random = new Random();
            var elements = Enumerable.Range(1, 10).Select(n => random.Next(1, 100)).ToList();

            BestTimeToBuyAndSellStock(elements).ToConsole("BestProfit:");
        }

        public int BestTimeToBuyAndSellStock(IList<int> elements)
        {
            var profit = 0;
            var buyPrice = 0;
            for (var i = 0; i < elements.Count - 1; i++)
            {
                if (buyPrice == 0 && elements[i] < elements[i + 1])
                {
                    profit -= elements[i];
                    buyPrice = elements[i];
                    continue;
                }

                if (buyPrice != 0 && elements[i] > elements[i + 1])
                {
                    profit += elements[i];
                    buyPrice = 0;
                }
            }

            return buyPrice == 0 ? profit : profit + elements.Last();
        }
    }
}