using System;
using System.Collections.Generic;

namespace CSharpNote.Data.DesignPatternMethod.SubClass
{
    public abstract class Command
    {
        protected Receiver receiver;

        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    public class AddCommond : Command
    {
        public AddCommond(Receiver receiver) :
            base(receiver)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("X + Y = {0}", receiver.X + receiver.Y);
        }
    }

    public class SubtractCommond : Command
    {
        public SubtractCommond(Receiver receiver) :
            base(receiver)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("X - Y = {0}", receiver.X - receiver.Y);
        }
    }

    public class MultiplicateCommond : Command
    {
        public MultiplicateCommond(Receiver receiver) :
            base(receiver)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("X * Y = {0}", receiver.X * receiver.Y);
        }
    }

    public class Receiver
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Receiver(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

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
