using System;
using System.Collections.Generic;

namespace CSharpNote.Data.DataStructure.Implement.HashTable
{
    /// <summary>
    ///     Array為基底容器 管理 HashTableArrayNode<TKey, TValue>
    /// </summary>
    public class HashTableArray<TKey, TValue>
    {
        private readonly HashTableArrayNode<TKey, TValue>[] array;

        public HashTableArray(int capacity)
        {
            array = new HashTableArrayNode<TKey, TValue>[capacity];

            for (var i = 0; i < capacity; i++)
            {
                array[i] = new HashTableArrayNode<TKey, TValue>();
            }
        }

        public int Capacity
        {
            get { return array.Length; }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                foreach (var node in array)
                {
                    foreach (var value in node.Values)
                    {
                        yield return value;
                    }
                }
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach (var node in array)
                {
                    foreach (var key in node.Keys)
                    {
                        yield return key;
                    }
                }
            }
        }

        public IEnumerable<HashTableNodePair<TKey, TValue>> Items
        {
            get
            {
                foreach (var node in array)
                {
                    foreach (var pair in node.Items)
                    {
                        yield return pair;
                    }
                }
            }
        }

        public void Add(TKey key, TValue value)
        {
            array[GetIndex(key)].Add(key, value);
        }

        public void Update(TKey key, TValue value)
        {
            array[GetIndex(key)].Update(key, value);
        }

        public bool Remove(TKey key)
        {
            return array[GetIndex(key)].Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return array[GetIndex(key)].TryGetValue(key, out value);
        }

        public void Clear()
        {
            foreach (var node in array)
            {
                node.Clear();
            }
        }

        private int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode()%Capacity);
        }
    }
}