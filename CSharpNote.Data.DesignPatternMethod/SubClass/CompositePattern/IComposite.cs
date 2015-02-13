namespace CSharpNote.Data.DesignPatternMethod.SubClass.CompositePattern
{
    public interface IComposite<T> : IComponent
    {
        void Add(T component);
        void Remove(T component);
    }
}