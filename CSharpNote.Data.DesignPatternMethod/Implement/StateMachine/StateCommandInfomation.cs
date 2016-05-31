namespace CSharpNote.Data.DesignPattern.Implement.StateMachine
{
    public class StateCommandInfomation
    {
        public StateCommandInfomation(State state, Command command)
        {
            State = state;
            Command = command;
        }

        public State State { get; private set; }
        public Command Command { get; private set; }

        public override int GetHashCode()
        {
            return 17 + 31*State.GetHashCode() ^ 31*Command.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as StateCommandInfomation;

            return other != null
                   && State == other.State
                   && Command == other.Command;
        }
    }
}