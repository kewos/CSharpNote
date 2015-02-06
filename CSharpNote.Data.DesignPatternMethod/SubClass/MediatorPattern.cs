using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Extendsions;

namespace CSharpNote.Data.DesignPatternMethod.SubClass
{
    public interface IGamePlayMediator
    {
        void PlayerWinTheGame(IGamePlayer player);
    }

    public class GamePlayMediator : IGamePlayMediator
    {
        private readonly List<IGamePlayer> gamePlayers;

        public GamePlayMediator(List<IGamePlayer> gamePlayers)
        {
            this.gamePlayers = gamePlayers;
        }

        public void PlayerWinTheGame(IGamePlayer gameplayer)
        {
            gamePlayers.Where(p => p != gameplayer).ForEach(p => p.Lost());
        }
    }

    public interface IGamePlayer
    {
        void Win(IGamePlayMediator mediator);
        void Lost();
    }

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