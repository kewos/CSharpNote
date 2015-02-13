using CSharpNote.Common.Extendsions;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.CompositePattern
{
    public class Leaf : IComponent
    {
        public void Execute(int depth = 0)
        {
            GetType().Name.ToConsole(new string('-', depth * 2));
        }
    }
}