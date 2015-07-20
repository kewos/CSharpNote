
namespace CSharpNote.Data.DesignPatternMethod.SubClass.IteratorPattern
{
    public interface IAggregate<TItem>
    {
        IIterator<TItem> GetIterator();
    }
}
    
