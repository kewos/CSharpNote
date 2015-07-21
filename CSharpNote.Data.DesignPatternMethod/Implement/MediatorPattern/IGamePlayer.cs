namespace CSharpNote.Data.DesignPatternMethod.Implement.MediatorPattern
{
    public interface IGamePlayer
    {
        void Win(IGamePlayMediator mediator);
        void Lost();
    }
}