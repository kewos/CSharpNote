namespace CSharpNote.Data.DesignPatternMethod.SubClass.MediatorPattern
{
    public interface IGamePlayer
    {
        void Win(IGamePlayMediator mediator);
        void Lost();
    }
}