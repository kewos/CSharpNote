﻿using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Extensions;

namespace CSharpNote.Data.DesignPattern.Implement.MediatorPattern
{
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
}