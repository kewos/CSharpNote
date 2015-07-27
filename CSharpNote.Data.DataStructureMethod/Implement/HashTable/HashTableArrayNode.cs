using System;
using System.Collections.Generic;

namespace CSharpNote.Data.DataStructure.Implement.HashTable
{
    /// <summary>
    /// LinkedList 當作基底容器管理 HashTableNodePair<TKey, TValue>
    /// </summary>
    public class HashTableArrayNode<TKey , TValue>
    {
        private LinkedList<HashTableNodePair<TKey, TValue>> items;

        public void Add(TKey key, TValue value)
        {
            if (items == null)
            {
                items = new LinkedList<HashTableNodePair<TKey, TValue>>(); 

            }

            foreach (HashTableNodePair<TKey, TValue> pair in items)
            {
                if (pair.Key.Equals(key))
                {
                    throw new ArgumentException("The collection already contains the key");
                }
            }

            items.AddFirst(new HashTableNodePair<TKey, TValue>(key, value)); 

        }

        public void Update(TKey key, TValue value)
        {
            bool updated = false;

            if (items != null)
            {
                foreach (HashTableNodePair<TKey, TValue> pair in items)
                {
                    if (pair.Key.Equals(key))
                    {
                        pair.Value = value;
                        updated = true; 
                    }
                }
            }

            if (!updated)
            {
                throw new ArgumentException("The collection does not contain the key");
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue); 

            bool found = false;

            if (items != null)
            {
                foreach (HashTableNodePair<TKey, TValue> pair in items)
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        found = true;
                    }
                }
            }

            return found; 
        }

        public bool Remove(TKey key)
        {
            bool remove = false;

            if (items != null)
            {
                foreach (HashTableNodePair<TKey, TValue> pair in items)
                {
                    if (pair.Key.Equals(key))
                    {
                        items.Remove(pair);
                        remove = true;
                        break;
                    }
                }
            }

            return remove; 
        }

        public void Clear()
        {
            if (items != null)
            {
                items.Clear(); 
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                if (items != null)
                {
                    foreach (HashTableNodePair<TKey, TValue> node in items)
                    {
                        yield return node.Value;
                    }
                }
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                if (items != null)
                {
                    foreach (HashTableNodePair<TKey, TValue> node in items)
                    {
                        yield return node.Key;
                    }
                }
            }
        }

        public IEnumerable<HashTableNodePair<TKey, TValue>> Items
        {
            get
            {
                if (items != null)
                {
                    foreach (HashTableNodePair<TKey, TValue> node in items)
                    {
                        yield return node;
                    }
                }
            }
        }
    }
}
