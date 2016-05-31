using System;
using System.Collections.Generic;

namespace CSharpNote.Data.DesignPattern.Implement.SingletonPattern
{
    public class SingletonD
    {
        private static readonly Dictionary<Type, object> dic;
        private static readonly object lockobj = new object();

        public TType Instance<TType>()
            where TType : new()
        {
            var type = typeof (TType);

            if (!dic.ContainsKey(type))
            {
                lock (lockobj)
                {
                    if (!dic.ContainsKey(type))
                    {
                        dic[type] = new TType();
                    }
                }
            }

            return dic[type] as dynamic;
        }
    }
}