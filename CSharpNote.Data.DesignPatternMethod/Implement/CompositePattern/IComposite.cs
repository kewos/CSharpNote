namespace CSharpNote.Data.DesignPatternMethod.SubClass.CompositePattern
{
    public interface IComposite<in T> : IComponent
        where T : IComponent
    {
        void Add(T component);
        void Remove(T component);
    }
}