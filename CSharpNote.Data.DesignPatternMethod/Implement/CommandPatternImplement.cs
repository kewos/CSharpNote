using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.CommandPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class CommandPatternImplement : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var receiver = new Receiver(20, 10);
            var invoker = new Invoker();

            invoker.SetCommand(new AddCommond(receiver));
            invoker.SetCommand(new SubtractCommond(receiver));
            invoker.SetCommand(new MultiplicateCommond(receiver));
            invoker.ExecuteCommand();
        }
    }
}