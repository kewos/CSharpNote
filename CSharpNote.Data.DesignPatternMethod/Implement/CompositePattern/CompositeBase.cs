using System.Collections.Generic;
using CSharpNote.Common.Extensions;

namespace CSharpNote.Data.DesignPattern.Implement.CompositePattern
{
    public abstract class CompositeBase<T> : IComposite<T>
        where T : IComponent
    {
        protected readonly IList<T> elements;

        protected CompositeBase()
            : this(new List<T>())
        {
        }

        protected CompositeBase(IList<T> elements)
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

        public virtual void Execute(int depth = 0)
        {
            GetType().Name.ToConsole(new string('-', depth++ * 2));

            elements.ForEach(element => element.Execute(depth));
        }
    }
}