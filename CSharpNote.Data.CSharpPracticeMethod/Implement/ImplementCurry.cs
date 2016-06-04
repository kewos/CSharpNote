using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class ImplementCurry : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            Func<int, int> subtractOne = x => x - 1;
            subtractOne.Curry()(1).ToConsole();

            Func<int, int, int> mutiple = (x, y) => x*y;
            mutiple.Curry()(8)(8).ToConsole();

            Func<int, int, int, int> subtractFisrt = (x, y, z) => x - y - z;
            subtractFisrt.Curry()(8)(5)(2).ToConsole();

            Func<int, int, int, int, int> add = (w, x, y, z) => w + x + y + z;
            add.Curry()(1)(2)(3)(4).ToConsole();
        }
    }
}