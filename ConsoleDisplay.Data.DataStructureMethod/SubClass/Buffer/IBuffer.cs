using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplay.Data.DataStructureMethod.SubClass
{
    public interface IBuffer<T>
    {
        void Write(T value);
        T Read();
    }
}
