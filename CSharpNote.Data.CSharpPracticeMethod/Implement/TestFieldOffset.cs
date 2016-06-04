using System.Runtime.InteropServices;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class TestFieldOffset : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var item = new TestFieldOffsetObject();
            item.a = 1;
            item.b.ToConsole();
            item.b = 2;
            item.a.ToConsole();
        }

        [StructLayout(LayoutKind.Explicit)]
        public class TestFieldOffsetObject
        {
            [FieldOffset(0)] public int a;

            [FieldOffset(0)] public int b;
        }
    }
}