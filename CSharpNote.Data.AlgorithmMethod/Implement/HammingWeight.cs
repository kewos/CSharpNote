using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://leetcode.com/problems/number-of-1-bits/
    public class HammingWeight : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            GetHammingWeight(1).ToConsole();
        }

        private int GetHammingWeight(uint n)
        {
            return Convert.ToString(n, 2).Count(x => x == '1');
        }
    }
}