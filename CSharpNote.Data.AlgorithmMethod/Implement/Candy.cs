using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class Candy : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            //https://oj.leetcode.com/problems/candy/
            //There are N children standing in a line. Each child is assigned a rating value.
            //You are giving candies to these children subjected to the following requirements:
            //Each child must have at least one candy.
            //Children with a higher rating get more candies than their neighbors.
            //What is the minimum candies you must give?
            var childredRates = new List<int> {2, 10, 1, 9, 100, 8, 7, 6};
            var candies = Enumerable.Repeat(0, 8).ToList();
            while (Enumerable.Range(0, childredRates.Count()).Any(n =>
            {
                var state = false;
                while (candies[n] == 0 || CompareWithNeighbors(childredRates, candies, n))
                {
                    state = true;
                    candies[n]++;
                }

                return state;
            }))

                Console.WriteLine(candies.Aggregate((a, b) => a + b));
        }

        private bool CompareWithNeighbors(List<int> childredRates, List<int> candies, int position)
        {
            if (position == 0)
                return
                    (CheckNeedAdd(childredRates[position], candies[position], childredRates[position + 1],
                        candies[position + 1]) ||
                     CheckNeedAdd(childredRates[position], candies[position], childredRates[childredRates.Count - 1],
                         candies[childredRates.Count - 1]));

            if (position >= childredRates.Count - 1)
                return
                    CheckNeedAdd(childredRates[position], candies[position], childredRates[position - 1],
                        candies[position - 1]) ||
                    CheckNeedAdd(childredRates[position], candies[position], childredRates[0], candies[0]);

            return
                CheckNeedAdd(childredRates[position], candies[position], childredRates[position - 1],
                    candies[position - 1]) ||
                CheckNeedAdd(childredRates[position], candies[position], childredRates[position + 1],
                    candies[position + 1]);
        }

        private bool CheckNeedAdd(int childredRate1, int candy1, int childredRate2, int candy2)
        {
            return (childredRate1 > childredRate2 && candy1 <= candy2) ? true : false;
        }
    }
}