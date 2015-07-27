namespace CSharpNote.Data.DesignPattern.Implement.StatePattern
{
    public class Context : IContext
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
}