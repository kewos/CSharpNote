using System;

namespace CSharpNote.Data.DesignPattern.Implement.ChainResponsibilityPattern
{
    public class HandlerCommand : IHandlerCommand
    {
        public HandlerCommand(Type commandType)
        {
            CommandType = commandType;
        }

        public Type CommandType { get; set; }
    }
}