using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DataStructure.Implement.Buffer;

namespace CSharpNote.Data.DataStructure.Implement
{
    public class TestBuffer : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var buffer = new Buffer<int>(3);
            buffer.Write(Enumerable.Range(0, 3));
            var assert = new List<int> {2, 1, 0};
            (buffer.Count() == 3).ToConsole("Count is 3:");
            buffer.All((index, element) => assert[index] == element).ToConsole("elements is {2, 1, 0}");

            "\n".ToConsole();
            try
            {
                var buffer1 = new Buffer<int>(3);
                buffer1.Write(Enumerable.Range(0, 4));
            }
            catch (Exception e)
            {
                (e is InvalidOperationException).ToConsole("ThrowInvalidOperationException:");
            }

            "\n".ToConsole();
            try
            {
                var buffer2 = new Buffer<int>(3);
                buffer2.Read();
            }
            catch (Exception e)
            {
                (e is InvalidOperationException).ToConsole("ThrowInvalidOperationException:");
            }

            var buffer3 = new Buffer<int>(3);
            buffer3.Write(Enumerable.Range(0, 1));
            (buffer3.Read() == 0).ToConsole("Read Item = 0:");
            (buffer3.Count() == 0).ToConsole("Count = 0:");
        }
    }
}