using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class BestTimetoBuyandSellStockIii : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            //https://oj.leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
            //Say you have an array for which the ith element is the price of a given stock on day i.
            //Design an algorithm to find the maximum profit. You may complete at most two transactions.
            //Note:
            //You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
            var prices = new List<int> { 10, 5, 8, 1, 5, 3, 9, 4, 2, 6, 5 };
            var set = new List<List<int>>();
            var p = 0;
            for (var i = 0; i < prices.Count() - 1; i++)
            {
                if (prices[i + 1] < prices[i])
                {
                    if (i != p)
                        set.Add(new List<int> { p, i });

                    p = i + 1;
                }

                if (i != prices.Count() - 2)
                    continue;

                if (i != p)
                    set.Add(new List<int> { p, i + 1 });
            }

            var maxProfitOfTwoTransaction =
                set.Select(n => prices[n[1]] - prices[n[0]])
                    .OrderByDescending(n => n)
                    .Take(2)
                    .Sum();

            Console.WriteLine(maxProfitOfTwoTransaction);
        }
    }
}