using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.MediatorPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class MediatorPatternImplement : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            Func<int, string> convertToString = number => ((char) (65 + number)).ToString();
            var players = Enumerable.Range(0, 5)
                .Select(n => new GamePlayer(convertToString(n)))
                .ToList<IGamePlayer>();
            var mediator = new GamePlayMediator(players);
            players.ForEach(p => p.Win(mediator));
        }
    }
}