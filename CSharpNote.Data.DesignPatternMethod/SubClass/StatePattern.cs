using System;
using System.Security.Cryptography.X509Certificates;
using CSharpNote.Common.Extendsions;

namespace CSharpNote.Data.DesignPatternMethod.SubClass
{
    public class Context
    {
        private IState state;

        public Context(IState state)
        {
            this.state = state;
        }

        public void SetState(IState state)
        {
            this.state = state;
        }

        public void Execute()
        {
            state.Handle(this);
        }
    }

    public interface IState
    {
        void Handle(Context context);
    }

    public class StateA : IState
    {
        public void Handle(Context context)
        {
            GetType().Name.ToConsole("Run");
            context.SetState(new StateB());
        }
    }

    public class StateB : IState
    {
        public void Handle(Context context)
        {
            GetType().Name.ToConsole("Run");
            context.SetState(new StateC());
        }
    }

    public class StateC : IState
    {
        public void Handle(Context context)
        {
            GetType().Name.ToConsole("Run");
            context.SetState(new StateD());
        }
    }

    public class StateD : IState
    {
        public void Handle(Context context)
        {
            GetType().Name.ToConsole("Run");
            context.SetState(new StateA());
        }
    }
}
