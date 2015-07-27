namespace CSharpNote.Data.DesignPattern.Implement.StatePattern
{
    public interface IState
    {
        void Handle(Context context);
    }
}