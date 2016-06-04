using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Contracts;

namespace CSharpNote.Core.Implements
{
    [AopClassAttribue]
    public abstract class AbstractExecuteModule : ContextBoundObject, IExecuteModule
    {
        public abstract void Execute();
    }
}