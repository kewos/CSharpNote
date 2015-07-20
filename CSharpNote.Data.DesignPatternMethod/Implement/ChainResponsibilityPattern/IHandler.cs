namespace CSharpNote.Data.DesignPatternMethod.SubClass.ChainResponsibilityPattern
{
    public interface IHandler
    {
        void Execute(IHandlerCommand handlerCommand);
    }
}