using System;
using System.Collections.Generic;

namespace ConsoleDisplay.Data.DataStructureMethod.SubClass.HashTable
{
    public class HashTable<TKey, TValue>
    {
        private const double fillFactor = 0.75;
        private int maxItemAtCurrentSize;
        private int count;
        private HashTableArray<TKey, TValue> array;

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
            maxItemAtCurrentSize = (int)(capacity * fillFactor) + 1;
        }

        public void Add(TKey key, TValue value)
        {
            CheckMaxItemAtCurrentSize();

            array.Add(key, value);
            count++;
        }

        private void CheckMaxItemAtCurrentSize()
        {
            //省空間不夠用才加大
            if (count >= maxItemAtCurrentSize)
            {
                var largerArray = new HashTableArray<TKey, TValue>(array.Capacity * 2);

                foreach (HashTableNodePair<TKey, TValue> node in array.Items)
                {
                    largerArray.Add(node.Key, node.Value);
                }

                array = largerArray;
                maxItemAtCurrentSize = (int)(array.Capacity * fillFactor) + 1;
            }
        }

        public bool Remove(TKey key)
        {
            bool removed = array.Remove(key);

            if (removed)
            {
                count--;
            }

            return removed;
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
            set
            {
                array.Update(key, value);
            }
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
            foreach (TValue foundValue in array.Values)
            {
                if (value.Equals(foundValue))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach (TKey key in array.Keys)
                {
                    yield return key;
                }
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                foreach (TValue value in array.Values)
                {
                    yield return value;
                }
            }
        }

        public void Clear()
        {
            array.Clear();
            count = 0;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }
    }
}
