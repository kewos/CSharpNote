using System.Collections.Generic;

namespace CSharpNote.Data.DesignPattern.Implement.CompositePattern
{
    public class CompositeB : CompositeBase<IComponent>
    {
        public CompositeB(IList<IComponent> elements)
            : base(elements)
        {
        }

        public CompositeB()
        {
        }
    }
}