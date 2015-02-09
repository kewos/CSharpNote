using System;
using CSharpNote.Common.Extendsions;

namespace CSharpNote.Data.DesignPatternMethod.SubClass
{
    public interface IHandlerCommand
    {
        Type CommandType { get; set; }
    }

    public class HandlerCommand : IHandlerCommand
    {
        private Type commandType;
        public Type CommandType
        {
            get { return commandType; }
            set { commandType = value; }
        }

        public HandlerCommand(Type commandType)
        {
            CommandType = commandType;
        }
    }

    public interface IHandler
    {
        void Execute(IHandlerCommand handlerCommand);
    }

    public abstract class AbstractHandler : IHandler
    {
        private readonly IHandler nextHandler;

        protected AbstractHandler(IHandler handler)
        {
            nextHandler = handler;
        }

        public void Execute(IHandlerCommand handlerCommand)
        {
            if (handlerCommand == null) 
                throw new ArgumentNullException("IHandlerCommandIsNull");

            if ((handlerCommand.CommandType == GetType()))
                 DoSometing();
            else
                 NextProcess(handlerCommand);
        }

        private void NextProcess(IHandlerCommand handlerCommand)
        {
            if (hasNextProcess) 
                nextHandler.Execute(handlerCommand);
            else
                "NoFindMatchHandler".ToConsole();
        }

        private bool hasNextProcess 
        {
            get { return (nextHandler != null); }
        }

        protected abstract void DoSometing();
    }

    public class HandlerA : AbstractHandler
    {
        public HandlerA()
            : base(new HandlerB())
        {
        }

        protected override void DoSometing()
        {
            "Execute HandlerA".ToConsole();
        }
    }

    public class HandlerB : AbstractHandler
    {
        public HandlerB()
            : base(new HandlerC())
        {
        }

        protected override void DoSometing()
        {
            "Execute HandlerB".ToConsole();
        }
    }

    public class HandlerC : AbstractHandler
    {
        public HandlerC()
            : base(new HandlerD())
        {
        }

        protected override void DoSometing()
        {
            "Execute HandlerC".ToConsole();
        }
    }

    public class HandlerD : AbstractHandler
    {
        public HandlerD()
            :base(null)
        {
        }

        protected override void DoSometing()
        {
            "Execute HandlerD".ToConsole();
        }
    }
}
