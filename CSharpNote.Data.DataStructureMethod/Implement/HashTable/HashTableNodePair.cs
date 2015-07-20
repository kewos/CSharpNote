
namespace  CSharpNote.Data.DataStructureMethod.Implement.HashTable
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
