namespace CSharpNote.Data.DesignPattern.Implement.StatePattern
{
    public interface IContext
    {
        void SetState(IState state);
        void Execute();
    }
}