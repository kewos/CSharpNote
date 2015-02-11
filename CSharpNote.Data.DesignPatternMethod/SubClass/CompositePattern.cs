using System;
using System.Collections.Generic;
using CSharpNote.Common.Extendsions;

namespace CSharpNote.Data.DesignPatternMethod.SubClass
{
    public interface IComponent
    {
        void Execute(int depth);
    }

    public interface IComposite<T> : IComponent
    {
        void Add(T component);
        void Remove(T component);
    }

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

    public class CompositeA : CompositeBase<IComponent>
    {
        public CompositeA(IList<IComponent> elements)
            : base(elements)
        {
        }

        public CompositeA()
        {
        }

        public override void Execute(int depth = 0)
        {
            GetType().Name.ToConsole(new string('-', depth++));
            elements.ForEach(element => element.Execute(depth));
        }
    }

    public class CompositeB : CompositeBase<IComponent>
    {
        public CompositeB(IList<IComponent> elements)
            : base(elements)
        {
        }

        public CompositeB()
        {
        }

        public override void Execute(int depth = 0)
        {
            GetType().Name.ToConsole(new string('-', depth++));
            elements.ForEach(element => element.Execute(depth));
        }
    }

    public class Leaf : IComponent
    {
        public void Execute(int depth = 0)
        {
            GetType().Name.ToConsole(new string('-', depth));
        }
    }
}
