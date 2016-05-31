namespace CSharpNote.Data.DataStructure.Implement.HashTable
{
    /// <summary>
    ///     KeyValuePair
    /// </summary>
    public class HashTableNodePair<TKey, TValue>
    {
        public HashTableNodePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key { get; private set; }
        public TValue Value { get; set; }
    }
}