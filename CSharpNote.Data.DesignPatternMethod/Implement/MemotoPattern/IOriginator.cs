
namespace CSharpNote.Data.DesignPatternMethod.Implement.MemotoPattern
{
    public interface IOriginator
    {
        Memento CreateMemento();
        void RestoreMemento(Memento memento);
    }
}
