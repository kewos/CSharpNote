using System.Collections.Generic;
using CSharpNote.Common.Extensions;

namespace CSharpNote.Data.DesignPatternMethod.Implement.CompositePattern
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