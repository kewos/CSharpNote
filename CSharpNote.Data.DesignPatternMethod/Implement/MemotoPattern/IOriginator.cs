
namespace CSharpNote.Data.DesignPatternMethod.SubClass.MemotoPattern
{
    public interface IOriginator
    {
        Memento CreateMemento();
        void RestoreMemento(Memento memento);
    }
}
