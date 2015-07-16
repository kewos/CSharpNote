using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.MemotoPattern
{
    public class Caretaker : ICaretaker
    {
        private readonly List<Memento> mementos;

        public Caretaker()
        {
            mementos = new List<Memento>();
        }

        public Memento GetById(int id)
        {
            if (mementos == null || id > mementos.Count())
            {
                throw new Exception();
            }
            return mementos.Skip(id).First();
        }

        public Memento GetLast()
        {
            if (mementos == null || !mementos.Any())
            {
                throw new Exception();
            }
            return mementos.Last();
        }

        public IEnumerable<Memento> GetAll()
        { 
            if (mementos == null || !mementos.Any())
            {
                throw new Exception();
            }
            return mementos;
        }

        public void SetMemento(Memento memento)
        {
            mementos.Add(memento);
        }
    }
}
