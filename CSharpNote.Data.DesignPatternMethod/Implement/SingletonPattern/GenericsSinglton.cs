using System;
using System.Collections.Generic;

namespace CSharpNote.Data.DesignPattern.Implement.SingletonPattern
{
    public class GenericsSinglton<T> where T : class, new()
    {
        private static readonly IDictionary<Type, object> dictionary = new Dictionary<Type, object>();

        private GenericsSinglton()
        {
        }

        public T Instance()
        {
            lock (dictionary)
            {
                object value;
                if (dictionary.TryGetValue(typeof(T), out value))
                {
                    return (T)value;
                }

                value = new T();
                dictionary.Add(typeof(T), value);

                return (T)value;
            }
        }
    }
}