namespace CSharpNote.Data.DesignPattern.Implement.IteratorPattern
{
    public interface IAggregate<TItem>
    {
        IIterator<TItem> GetIterator();
    }
}