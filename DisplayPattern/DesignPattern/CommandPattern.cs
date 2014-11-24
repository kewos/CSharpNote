using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayPattern.DesignPattern
{
    // "Command" 
    public abstract class Command
    {
        protected Receiver receiver;

        // Constructor 
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    // "ConcreteCommand" 
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

    // "Receiver" 
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

    // "Invoker" 
    public class Invoker
    {
        private List<Command> commands;

        public void SetCommand(Command command)
        {
            if (commands == null) commands = new List<Command>();
            commands.Add(command);
        }

        public void ExecuteCommand()
        {
            commands.ForEach(command => command.Execute());
        }
    }
}
