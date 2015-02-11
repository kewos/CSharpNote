using CSharpNote.Common.Extendsions;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.StatePattern
{
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