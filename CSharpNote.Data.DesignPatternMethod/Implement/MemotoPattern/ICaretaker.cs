
namespace CSharpNote.Data.DesignPattern.Implement.MemotoPattern
{
    public interface ICaretaker
    {
        System.Collections.Generic.IEnumerable<Memento> GetAll();
        Memento GetById(int id);
        Memento GetLast();
        void SetMemento(Memento memento);
    }
}
