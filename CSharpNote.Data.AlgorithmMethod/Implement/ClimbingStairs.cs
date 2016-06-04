using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //You are climbing a stair case. It takes n steps to reach to the top.
    //Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
    public class ClimbingStairs : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/climbing-stairs/")]
        public override void Execute()
        {
            Console.WriteLine(GetClimbingStairs(100));
        }

        private int GetClimbingStairs(int distinct)
        {
            if (distinct < 0)
                return 0;

            if (distinct <= 2)
                return distinct;

            return GetClimbingStairs(distinct - 2) + GetClimbingStairs(distinct - 1);
        }
    }
}