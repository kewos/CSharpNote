namespace CSharpNote.Data.DesignPattern.Implement.IteratorPattern
{
    public interface IIterator<TItem>
    {
        bool HasNext();
        TItem Next();
    }
}