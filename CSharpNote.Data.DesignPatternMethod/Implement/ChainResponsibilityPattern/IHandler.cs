namespace CSharpNote.Data.DesignPatternMethod.Implement.ChainResponsibilityPattern
{
    public interface IHandler
    {
        void Execute(IHandlerCommand handlerCommand);
    }
}