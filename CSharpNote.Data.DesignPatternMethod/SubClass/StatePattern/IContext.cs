namespace CSharpNote.Data.DesignPatternMethod.SubClass.StatePattern
{
    public interface IContext
    {
        void SetState(IState state);
        void Execute();
    }
}