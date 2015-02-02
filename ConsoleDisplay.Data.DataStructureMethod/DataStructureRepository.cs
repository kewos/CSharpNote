using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleDisplay.Common;
using ConsoleDisplay.Core.Contracts;
using ConsoleDisplay.Core.Implements;
using ConsoleDisplay.Data.DataStructureMethod.SubClass;

namespace ConsoleDisplay.Data.DataStructureMethod
{
    public class DataStructureMethodRepository : AbstractMethodRepository
    {
        [DisplayMethod]
        public void HashTableImplement()
        {
            var hashTable = new HashTable<int, int>();
            var elements = Enumerable.Range(0, 1000);

            elements.ForEach(element => hashTable.Add(element, element));
            (hashTable.Count == 1000).ToConsole("Add 1000 Items, Count is 1000");

            (hashTable[999] == 999).ToConsole("index:999 value is 999:");

            elements.ForEach(element => hashTable.Remove(element));
            (hashTable.Count == 0).ToConsole("Remove 1000 Items, Count is 0:");
        }

        [DisplayMethod]
        public void DequeImplement()
        {
            var deque = new Deque<int>(Enumerable.Range(5, 2)).EnqueueHead(1).EnqueueHead(2).EnqueueTail(3).EnqueueTail(4);
            var assert  = new List<int> (){ 2, 1, 5, 6, 3, 4 };
            deque.All((index, element) => element == assert[index]).ToConsole("element is { 2, 1, 5, 6, 3, 4 } :");
            
            "\n".ToConsole();
            (deque.DequeueHead() == 2).ToConsole("DequeueHead Get Head 2");
            var assert1 = new List<int>() { 1, 5, 6, 3, 4 };
            deque.All((index, element) => element == assert1[index]).ToConsole("element is { 1, 5, 6, 3, 4 } :");
            
            "\n".ToConsole();
            (deque.DequeueTail() == 4).ToConsole("DequeueTail Get Head 4");
            var assert2 = new List<int>() { 1, 5, 6, 3 };
            deque.All((index, element) => element == assert2[index]).ToConsole("element is { 1, 5, 6, 3 } :");
        }
    }
}
