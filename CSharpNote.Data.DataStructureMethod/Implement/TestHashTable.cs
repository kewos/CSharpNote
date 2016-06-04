using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DataStructure.Implement.HashTable;

namespace CSharpNote.Data.DataStructure.Implement
{
    public class TestHashTable : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            var hashTable = new HashTable<int, int>();
            var elements = Enumerable.Range(0, 1000);

            elements.ForEach(element => hashTable.Add(element, element));
            (hashTable.Count == 1000).ToConsole("Add 1000 Items, Count is 1000");

            (hashTable[999] == 999).ToConsole("index:999 value is 999:");

            elements.ForEach(element => hashTable.Remove(element));
            (hashTable.Count == 0).ToConsole("Remove 1000 Items, Count is 0:");
        }
    }
}