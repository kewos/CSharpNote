using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //You are climbing a stair case. It takes n steps to reach to the top.
    //Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
    public class ClimbingStairs¢¹ : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/climbing-stairs/")]
        public override void Execute()
        {
            Console.WriteLine(GetClimbingStairs¢¹(100));
        }

        private int GetClimbingStairs¢¹(int distinct)
        {
            if (distinct < 0)
                return 0;

            if (distinct <= 2)
                return distinct;

            var set = new List<int> {1, 2};
            for (var i = 2; i < distinct; i++)
                set.Add(set[i - 2] + set[i - 1]);

            return set.Last();
        }
    }
}