using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.ChainResponsibilityPattern
{
    public interface IHandlerCommand
    {
        Type CommandType { get; set; }
    }
}