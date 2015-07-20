using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.StateMachine
{
    public interface INext<out TNext>
    {
        TNext Next();
    }

    public interface IStateComand : INext<StateCommandInfomation>
    {
        void Execute();
    }

    public class CreateBegin : IStateComand
    {
        public StateCommandInfomation Next()
        {
            return new StateCommandInfomation(State.Create, Command.Pause);
        }

        public void Execute()
        {
            Console.WriteLine(GetType().Name);
        }
    }

    public class CreatePause : IStateComand
    {
        public StateCommandInfomation Next()
        {
            return new StateCommandInfomation(State.Create, Command.Resume);
        }

        public void Execute()
        {
            Console.WriteLine(GetType().Name);
        }
    }

    public class CreateResume : IStateComand
    {
        public StateCommandInfomation Next()
        {
            return new StateCommandInfomation(State.Create, Command.End);
        }

        public void Execute()
        {
            Console.WriteLine(GetType().Name);
        }
    }

    public class CreateEnd : IStateComand
    {
        public StateCommandInfomation Next()
        {
            return new StateCommandInfomation(State.Create, Command.End);
        }

        public void Execute()
        {
            Console.WriteLine(GetType().Name);
        }
    }
}