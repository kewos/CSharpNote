using System;

namespace CSharpNote.Data.DesignPatternMethod.Implement.ChainResponsibilityPattern
{
    public interface IHandlerCommand
    {
        Type CommandType { get; set; }
    }
}