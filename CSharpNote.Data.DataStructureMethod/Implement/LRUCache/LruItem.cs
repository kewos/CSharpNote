namespace CSharpNote.Data.DataStructure.Implement.LRUCache
{
    public class LruItem<TK, TV>
    {
        public LruItem(TK key, TV value)
        {
            Key = key;
            Value = value;
        }

        public TK Key { get; private set; }
        public TV Value { get; private set; }
    }
}