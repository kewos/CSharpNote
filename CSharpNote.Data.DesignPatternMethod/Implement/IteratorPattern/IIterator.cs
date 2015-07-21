
namespace CSharpNote.Data.DesignPatternMethod.Implement.IteratorPattern
{
    public interface IIterator<TItem>
    {
        bool HasNext();
        TItem Next();
    }
}
