using System.Collections.Generic;

namespace CSharpNote.Data.DesignPattern.Implement.MemotoPattern
{
    public interface ICaretaker
    {
        IEnumerable<Memento> GetAll();
        Memento GetById(int id);
        Memento GetLast();
        void SetMemento(Memento memento);
    }
}