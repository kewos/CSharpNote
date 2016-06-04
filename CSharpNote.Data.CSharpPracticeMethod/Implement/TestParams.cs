using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class TestParams : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            UseParams(1, "aaa", true, new object(), null);
        }

        private void UseParams(params object[] items)
        {
            foreach (var item in items)
            {
                if (item is int) Console.WriteLine("int");
                if (item == null) Console.WriteLine("null");
                if (item is object) Console.WriteLine("object");
                if (item is string) Console.WriteLine("string");
                if (item is bool) Console.WriteLine("bool");
            }
        }
    }
}