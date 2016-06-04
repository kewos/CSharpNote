using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class Reverse : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            GetReverse(1534236469).ToConsole();
        }

        private int GetReverse(int x)
        {
            if (x == int.MinValue || x == int.MaxValue)
                return 0;

            var sign = (x < 0) ? -1 : 1;
            x = Math.Abs(x);
            var tempString = string.Concat(x.ToString().OrderByDescending(y => y));
            try
            {
                checked
                {
                    return sign*Convert.ToInt32(tempString);
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}