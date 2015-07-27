using System.Collections.Generic;

namespace CSharpNote.Data.DesignPattern.Implement.CompositePattern
{
    public class CompositeA : CompositeBase<IComponent>
    {
        public CompositeA(IList<IComponent> elements)
            : base(elements)
        {
        }

        public CompositeA()
        {
        }
    }
}