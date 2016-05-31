using System.Collections.Generic;

namespace CSharpNote.Data.DataStructure.Implement.LRUCache
{
    public class LruCache<TK, TV>
    {
        private readonly Dictionary<TK, LinkedListNode<LruItem<TK, TV>>> cacheMap;
        private readonly int capacity;
        private readonly LinkedList<LruItem<TK, TV>> lruList;

        public LruCache(int capacity)
        {
            cacheMap = new Dictionary<TK, LinkedListNode<LruItem<TK, TV>>>();
            lruList = new LinkedList<LruItem<TK, TV>>();

            this.capacity = capacity;
        }

        public TV Get(TK key)
        {
            LinkedListNode<LruItem<TK, TV>> node;
            if (cacheMap.TryGetValue(key, out node))
            {
                var value = node.Value.Value;
                lruList.Remove(node);
                lruList.AddLast(node);
                return value;
            }
            return default(TV);
        }

        public void Add(TK key, TV val)
        {
            if (cacheMap.Count >= capacity)
            {
                RemoveFirst();
            }

            var cacheItem = new LruItem<TK, TV>(key, val);
            var node = new LinkedListNode<LruItem<TK, TV>>(cacheItem);
            lruList.AddLast(node);
            cacheMap.Add(key, node);
        }

        private void RemoveFirst()
        {
            var node = lruList.First;
            lruList.RemoveFirst();
            cacheMap.Remove(node.Value.Key);
        }
    }
}