namespace CSharpNote.Data.DesignPattern.Implement.ReactPattern
{
    public interface IReactor
    {
        void RegisterHandle(IEventHandler eventHandler);
        void RemoveHandle(IEventHandler eventHandler);
        void HandleEvents();
    }
}