using System.Collections.Generic;

namespace CSharpNote.Data.DesignPatternMethod.Implement.CommandPattern
{
    public class Invoker
    {
        private readonly List<Command> commands;

        public Invoker()
        {
            commands = new List<Command>();
        }

        public void SetCommand(Command command)
        {
            commands.Add(command);
        }

        public void ExecuteCommand()
        {
            commands.ForEach(command => command.Execute());
        }
    }
}