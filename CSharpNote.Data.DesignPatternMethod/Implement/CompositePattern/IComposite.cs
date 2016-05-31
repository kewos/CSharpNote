namespace CSharpNote.Data.DesignPattern.Implement.CompositePattern
{
    public interface IComposite<in T> : IComponent
        where T : IComponent
    {
        void Add(T component);
        void Remove(T component);
    }
}