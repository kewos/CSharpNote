using System;

namespace CSharpNote.Data.DesignPattern.Implement.ChainResponsibilityPattern
{
    public interface IHandlerCommand
    {
        Type CommandType { get; set; }
    }
}