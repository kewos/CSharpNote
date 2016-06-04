using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
    //Say you have an array for which the ith element is the price of a given stock on day i.
    //Design an algorithm to find the maximum profit. You may complete as many transactions as you like 
    //(ie, buy one and sell one share of the stock multiple times). However, 
    //you may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
    public class BestTimetoBuyandSellStockIi : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var prices = new List<int> {10, 5, 8, 1, 5, 3, 9, 4, 2, 6, 7};
            var totalProfit = 0;
            for (var i = 0; i < prices.Count() - 1; i++)
            {
                if (prices[i + 1] > prices[i])
                    totalProfit += prices[i + 1] - prices[i];
            }

            Console.WriteLine(totalProfit);
        }
    }
}