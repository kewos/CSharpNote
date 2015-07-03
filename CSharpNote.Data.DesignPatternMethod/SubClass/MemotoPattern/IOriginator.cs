using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.MemotoPattern
{
    public interface IOriginator
    {
        Memento CreateMemento();
        void RestoreMemento(Memento memento);
    }
}
