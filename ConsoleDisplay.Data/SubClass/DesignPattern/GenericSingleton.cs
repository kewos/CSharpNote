using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplay.Data.SubClass.DesignPattern
{
    public class GenericSingleton<T> 
        where T : class, new()
    {
        private static T instance;

        private GenericSingleton()
        {
        }

        public static T Instance()
        {
            if (instance == (T)null) 
                instance = new T();
            return instance;
        }
    }
}
