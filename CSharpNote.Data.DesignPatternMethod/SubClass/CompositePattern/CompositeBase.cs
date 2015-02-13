using System.Collections.Generic;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.CompositePattern
{
    public abstract class CompositeBase<T> : IComposite<T>
    {
        protected readonly IList<T> elements;

        public CompositeBase()
        {
            elements = new List<T>();
        }

        public CompositeBase(IList<T> elements)
        {
            this.elements = elements;
        }

        public void Add(T component)
        {
            elements.Add(component);
        }

        public void Remove(T component)
        {
            elements.Remove(component);
        }

        public abstract void Execute(int depth);
    }
}