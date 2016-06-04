using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/best-time-to-buy-and-sell-stock/
    //Say you have an array for which the ith element is the price of a given stock on day i.
    //If you were only permitted to complete at most one transaction (ie, buy one and sell one share of the stock), design an algorithm to find the maximum profit.
    public class BestTimetoBuyandSellStock : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var price = new List<int> {2, 1};

            Console.WriteLine(GetBestTimeToBuyAndSell(price));
        }

        private int GetBestTimeToBuyAndSell(List<int> prices)
        {
            if (prices == null
                || !prices.Any()
                || prices.Any(p => p < 0))
                return 0;

            var min = new List<int> {0};
            var maxBenifit = 0;
            for (var index = 1; index < prices.Count(); index++)
            {
                if (prices[index] > prices[index - 1])
                {
                    maxBenifit = Math.Max(maxBenifit, min.Max(n => prices[index] - prices[n]));
                    continue;
                }

                if (prices[index] < prices[index - 1])
                {
                    min.Add(index);
                }
            }

            return maxBenifit;
        }
    }
}