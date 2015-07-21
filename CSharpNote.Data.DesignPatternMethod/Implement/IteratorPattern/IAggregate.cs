
namespace CSharpNote.Data.DesignPatternMethod.Implement.IteratorPattern
{
    public interface IAggregate<TItem>
    {
        IIterator<TItem> GetIterator();
    }
}
    
