using System.Collections.Generic;

namespace CSharpNote.Data.DesignPattern.Implement.StateMachine
{
    public class StateCommandHandler
    {
        private readonly Dictionary<StateCommandInfomation, IStateComand> commandSet;
        private StateCommandInfomation currentState;

        public StateCommandHandler(StateCommandInfomation currentState,
            Dictionary<StateCommandInfomation, IStateComand> commandSet)
        {
            this.currentState = currentState;
            this.commandSet = commandSet;
        }

        public StateCommandHandler() : 
            this(new StateCommandInfomation(State.Create, Command.Begin),
            new Dictionary<StateCommandInfomation, IStateComand>
            {
                { new StateCommandInfomation(State.Create, Command.Begin), new CreateBegin()},
                { new StateCommandInfomation(State.Create, Command.Pause), new CreatePause()},
                { new StateCommandInfomation(State.Create, Command.Resume), new CreateResume()},
                { new StateCommandInfomation(State.Create, Command.End), new CreateEnd()},
            })
        {
        }

        public void Execute()
        {
            var i = 0;
            while (commandSet.ContainsKey(currentState) && i++ < 100)
            {
                commandSet[currentState].Execute();
                currentState = commandSet[currentState].Next();
            }
        }
    }
}