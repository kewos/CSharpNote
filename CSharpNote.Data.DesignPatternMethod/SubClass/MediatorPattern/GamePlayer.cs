using CSharpNote.Common.Extendsions;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.MediatorPattern
{
    public class GamePlayer : IGamePlayer
    {
        private readonly string name;

        public GamePlayer(string name)
        {
            this.name = name;
        }

        public void Win(IGamePlayMediator mediator)
        {
            " : I Win(^_____^)".ToConsole(name);
            mediator.PlayerWinTheGame(this);
            "".ToConsole();
        }

        public void Lost()
        {
            " : I Lost(T_____T)".ToConsole(name);
        }
    }
}