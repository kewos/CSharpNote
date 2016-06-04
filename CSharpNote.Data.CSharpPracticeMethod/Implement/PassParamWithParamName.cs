using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class PassParamWithParamName : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            PassParam(1, "2", true);
            PassParam(c: true, b: "2", a: 1);
        }

        private void PassParam(int a, string b, bool c)
        {
            Console.WriteLine("{0}{1}{2}", a, b, c);
        }
    }
}