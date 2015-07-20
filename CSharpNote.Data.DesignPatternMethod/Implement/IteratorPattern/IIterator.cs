
namespace CSharpNote.Data.DesignPatternMethod.SubClass.IteratorPattern
{
    public interface IIterator<TItem>
    {
        bool HasNext();
        TItem Next();
    }
}
