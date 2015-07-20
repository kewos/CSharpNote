using System.Collections.Generic;

namespace CSharpNote.Data.DataStructureMethod.Implement.LRUCache
{
    public class LRUCache<TK, TV>
    {
        private readonly int capacity;
        private readonly Dictionary<TK, LinkedListNode<LRUItem<TK, TV>>> cacheMap;
        private readonly LinkedList<LRUItem<TK, TV>> lruList;

        public LRUCache(int capacity)
        {
            cacheMap = new Dictionary<TK, LinkedListNode<LRUItem<TK, TV>>>();
            lruList = new LinkedList<LRUItem<TK, TV>>();

            this.capacity = capacity;
        }

        public TV Get(TK key)
        {
            LinkedListNode<LRUItem<TK, TV>> node;
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

            var cacheItem = new LRUItem<TK, TV>(key, val);
            var node = new LinkedListNode<LRUItem<TK, TV>>(cacheItem);
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