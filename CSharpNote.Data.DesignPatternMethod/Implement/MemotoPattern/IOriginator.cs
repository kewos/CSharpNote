namespace CSharpNote.Data.DesignPattern.Implement.MemotoPattern
{
    public interface IOriginator
    {
        Memento CreateMemento();
        void RestoreMemento(Memento memento);
    }
}