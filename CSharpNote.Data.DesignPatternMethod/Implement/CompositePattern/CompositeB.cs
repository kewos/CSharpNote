using System.Collections.Generic;
using CSharpNote.Common.Extensions;

namespace CSharpNote.Data.DesignPatternMethod.Implement.CompositePattern
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