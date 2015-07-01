using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.SingletonPattern
{
    public class SingletonD
    {
        private static readonly Dictionary<Type, object> dic;
        private static readonly object lockobj = new object();

        public TType Instance<TType>()
            where TType : new()
        {
            var type = typeof(TType);

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
