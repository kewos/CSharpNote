using System.Collections.Generic;

namespace CSharpNote.Common.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        ///     Key存在於字典取得字典裡的Value不存在取得預設值
        /// </summary>
        public static TValue GetValueOrDefault<TKey, TValue>
            (this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            TValue value;
            return dictionary.TryGetValue(key, out value)
                ? value
                : defaultValue;
        }

        /// <summary>
        ///     Key不存在則新增
        /// </summary>
        public static IDictionary<TKey, TValue> TryAdd<TKey, TValue>
            (this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, value);
            }
            return dictionary;
        }

        /// <summary>
        ///     新增或替換
        /// </summary>
        public static IDictionary<TKey, TValue> AddOrReplace<TKey, TValue>
            (this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            dictionary[key] = value;
            return dictionary;
        }
    }
}