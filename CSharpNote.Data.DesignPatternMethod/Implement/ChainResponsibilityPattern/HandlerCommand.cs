using System;

namespace CSharpNote.Data.DesignPatternMethod.Implement.ChainResponsibilityPattern
{
    public class HandlerCommand : IHandlerCommand
    {
        private Type commandType;
        public Type CommandType
        {
            get { return commandType; }
            set { commandType = value; }
        }

        public HandlerCommand(Type commandType)
        {
            CommandType = commandType;
        }
    }
}