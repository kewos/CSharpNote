using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DataStructure.Implement.Buffer;

namespace CSharpNote.Data.DataStructure.Implement
{
    public class TestCircularBuffer : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            var circularBuffer = new CircularBuffer<int>(3);
            circularBuffer.Write(Enumerable.Range(0, 3));
            var assert = new List<int> { 0, 1, 2 };
            (circularBuffer.Count() == 3).ToConsole("Count is 3:");
            circularBuffer.All((index, element) => assert[index] == element).ToConsole("elements is {0, 1, 2}");

            "\n".ToConsole();
            var circularBuffer1 = new CircularBuffer<int>(3);
            circularBuffer1.Write(Enumerable.Range(0, 4));
            var assert1 = new List<int> { 1, 2, 3 };
            (circularBuffer1.Count() == 3).ToConsole("Count is 3:");
            circularBuffer1.All((index, element) => assert1[index] == element).ToConsole("elements is { 1, 2, 3 }");

            "\n".ToConsole();
            var circularBuffer2 = new CircularBuffer<int>(3);
            circularBuffer2.Write(Enumerable.Range(0, 3));
            var assert2 = new List<int> { 1, 2 };
            (circularBuffer2.Read() == 0).ToConsole("Read is 0:");
            (circularBuffer2.Count() == 2).ToConsole("Count is 2:");
            circularBuffer2.All((index, element) => assert2[index] == element).ToConsole("elements is {1, 2}");
        }
    }
}