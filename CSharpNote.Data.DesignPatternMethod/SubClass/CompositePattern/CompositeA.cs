using System.Collections.Generic;
using CSharpNote.Common.Extendsions;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.CompositePattern
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

        public override void Execute(int depth = 0)
        {
            GetType().Name.ToConsole(new string('-', depth++ * 2));
            elements.ForEach(element => element.Execute(depth));
        }
    }
}