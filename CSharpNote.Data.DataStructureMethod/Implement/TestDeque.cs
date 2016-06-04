using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DataStructure.Implement.Queue;

namespace CSharpNote.Data.DataStructure.Implement
{
    public class TestDeque : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var deque =
                new Deque<int>(Enumerable.Range(5, 2)).EnqueueHead(1).EnqueueHead(2).EnqueueTail(3).EnqueueTail(4);
            var assert = new List<int> {2, 1, 5, 6, 3, 4};
            deque.All((index, element) => element == assert[index]).ToConsole("elements is { 2, 1, 5, 6, 3, 4 } :");

            "\n".ToConsole();
            var deque1 =
                new Deque<int>(Enumerable.Range(5, 2)).EnqueueHead(1).EnqueueHead(2).EnqueueTail(3).EnqueueTail(4);
            (deque1.DequeueHead() == 2).ToConsole("DequeueHead Get Head 2");
            var assert1 = new List<int> {1, 5, 6, 3, 4};
            deque1.All((index, element) => element == assert1[index]).ToConsole("elements is { 1, 5, 6, 3, 4 } :");

            "\n".ToConsole();
            var deque2 = new Deque<int>(Enumerable.Range(5, 2)).EnqueueHead(1).EnqueueTail(3).EnqueueTail(4);
            (deque2.DequeueTail() == 4).ToConsole("DequeueTail Get Head 4");
            var assert2 = new List<int> {1, 5, 6, 3};
            deque2.All((index, element) => element == assert2[index]).ToConsole("elements is { 1, 5, 6, 3 } :");
        }
    }
}