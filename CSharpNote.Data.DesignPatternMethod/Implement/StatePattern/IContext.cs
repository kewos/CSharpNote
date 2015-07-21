namespace CSharpNote.Data.DesignPatternMethod.Implement.StatePattern
{
    public interface IContext
    {
        void SetState(IState state);
        void Execute();
    }
}