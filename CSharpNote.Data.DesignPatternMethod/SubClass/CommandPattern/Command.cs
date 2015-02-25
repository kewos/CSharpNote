using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.CommandPattern
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
}