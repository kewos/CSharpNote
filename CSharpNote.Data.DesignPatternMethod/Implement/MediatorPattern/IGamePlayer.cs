namespace CSharpNote.Data.DesignPattern.Implement.MediatorPattern
{
    public interface IGamePlayer
    {
        void Win(IGamePlayMediator mediator);
        void Lost();
    }
}