using System;
using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DataStructure.Implement.Queue;

namespace CSharpNote.Data.DataStructure.Implement
{
    public class TestCircularQueue : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            var circularQueue = new CircularQueue<int>(3).Enqueue(1).Enqueue(2).Enqueue(3);
            var assert = new List<int> { 1, 2, 3 };
            circularQueue.All((index, element) => element == assert[index]).ToConsole("elements is {1, 2, 3}:");
            (circularQueue.Count == 3).ToConsole("Count is 3:");

            "\n".ToConsole();
            var circularQueue1 = new CircularQueue<int>(3).Enqueue(1).Enqueue(2).Enqueue(3).Enqueue(4);
            var assert1 = new List<int> { 2, 3, 4 };
            circularQueue1.All((index, element) => element == assert1[index]).ToConsole("elements is {2, 3, 4}:");
            (circularQueue1.Count == 3).ToConsole("Count is 3:");

            "\n".ToConsole();
            var circularQueue2 = new CircularQueue<int>(3).Enqueue(2).Enqueue(3).Enqueue(4);
            (circularQueue2.Dequeue() == 2).ToConsole("element is 2:");
            var assert2 = new List<int> { 3, 4 };
            circularQueue2.All((index, element) => element == assert2[index]).ToConsole("elements is {3, 4}:");

            "\n".ToConsole();
            var circularQueue3 = new CircularQueue<int>(3).Enqueue(3).Enqueue(4);
            (circularQueue3.Peek() == 3).ToConsole("element is 3:");
            var assert3 = new List<int> { 3, 4 };
            circularQueue3.All((index, element) => element == assert3[index]).ToConsole("elements is {3, 4}:");

            "\n".ToConsole();
            var circularQueue4 = new CircularQueue<int>(3);
            var assert4 = new List<int>();
            circularQueue4.All((index, element) => element == assert4[index]).ToConsole("elements is {}:");

            "\n".ToConsole();
            try
            {
                var circularQueue5 = new CircularQueue<int>(3);
                circularQueue5.Dequeue();
            }
            catch (Exception e)
            {
                (e is InvalidOperationException).ToConsole("throw InvalidOperationException:");
            }
        }
    }
}