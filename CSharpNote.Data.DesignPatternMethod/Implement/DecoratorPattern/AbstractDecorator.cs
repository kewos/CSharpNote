using System;

namespace CSharpNote.Data.DesignPatternMethod.Implement.DecoratorPattern
{
    public abstract class AbstractDecorator : IComponent
    {
        protected readonly IComponent component;

        protected AbstractDecorator(IComponent component)
        {
            if (component == null)
                throw new ArgumentException();
            this.component = component;
        }

        public abstract string Operation();
    }
}