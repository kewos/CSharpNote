using System;
using System.Collections.Generic;

namespace CSharpNote.Data.DataStructure.Implement.HashTable
{
    public class HashTable<TKey, TValue>
    {
        private const double FILL_FACTOR = 0.75;
        private HashTableArray<TKey, TValue> array;
        private int maxItemAtCurrentSize;

        public HashTable() : this(1000)
        {
        }

        public HashTable(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException("initialCapacity");
            }

            array = new HashTableArray<TKey, TValue>(capacity);
            maxItemAtCurrentSize = (int) (capacity*FILL_FACTOR) + 1;
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue value;

                if (!array.TryGetValue(key, out value))
                {
                    throw new ArgumentException("key");
                }

                return value;
            }
            set { array.Update(key, value); }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach (var key in array.Keys)
                {
                    yield return key;
                }
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                foreach (var value in array.Values)
                {
                    yield return value;
                }
            }
        }

        public int Count { get; private set; }

        public void Add(TKey key, TValue value)
        {
            CheckMaxItemAtCurrentSize();

            array.Add(key, value);
            Count++;
        }

        private void CheckMaxItemAtCurrentSize()
        {
            //省空間不夠用才加大
            if (Count >= maxItemAtCurrentSize)
            {
                var largerArray = new HashTableArray<TKey, TValue>(array.Capacity*2);

                foreach (var node in array.Items)
                {
                    largerArray.Add(node.Key, node.Value);
                }

                array = largerArray;
                maxItemAtCurrentSize = (int) (array.Capacity*FILL_FACTOR) + 1;
            }
        }

        public bool Remove(TKey key)
        {
            var removed = array.Remove(key);

            if (removed)
            {
                Count--;
            }

            return removed;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return array.TryGetValue(key, out value);
        }

        public bool ContainsKey(TKey key)
        {
            TValue value;
            return array.TryGetValue(key, out value);
        }

        public bool ContainsValue(TValue value)
        {
            foreach (var foundValue in array.Values)
            {
                if (value.Equals(foundValue))
                {
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            array.Clear();
            Count = 0;
        }
    }
}