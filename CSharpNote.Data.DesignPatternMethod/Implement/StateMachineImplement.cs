using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.StateMachine;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class StateMachineImplement : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            new StateCommandHandler().Execute();
        }
    }
}