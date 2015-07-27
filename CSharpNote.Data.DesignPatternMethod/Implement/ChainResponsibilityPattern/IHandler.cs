namespace CSharpNote.Data.DesignPattern.Implement.ChainResponsibilityPattern
{
    public interface IHandler
    {
        void Execute(IHandlerCommand handlerCommand);
    }
}