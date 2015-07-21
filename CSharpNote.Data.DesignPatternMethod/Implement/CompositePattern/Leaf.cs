using CSharpNote.Common.Extensions;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.CompositePattern
{
    public class Leaf : IComponent
    {
        public void Execute(int depth)
        {
            GetType().Name.ToConsole(new string('-', depth * 2));
        }
    }
}