using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class ComputeArea : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            //https://leetcode.com/problems/rectangle-area/
            DoComputeArea(-3, 0, 3, 4, 0, -1, 9, 2).ToConsole();
        }

        private int DoComputeArea(int a, int b, int c, int d, int e, int f, int g, int h)
        {
            var areaOfSqrA = (c - a)*(d - b);
            var areaOfSqrB = (g - e)*(h - f);

            var left = Math.Max(a, e);
            var right = Math.Min(g, c);
            var bottom = Math.Max(f, b);
            var top = Math.Min(d, h);

            var overlap = 0;
            if (right > left && top > bottom)
                overlap = (right - left)*(top - bottom);

            return areaOfSqrA + areaOfSqrB - overlap;
        }
    }
}