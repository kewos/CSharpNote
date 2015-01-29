using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  ConsoleDisplay.Data.DataStructureMethod.SubClass
{
    /// <summary>
    /// KeyValuePair
    /// </summary>
    public class HashTableNodePair<TKey, TValue>
    {
        public TKey Key { get; private set; }
        public TValue Value { get; set; }

        public HashTableNodePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}
