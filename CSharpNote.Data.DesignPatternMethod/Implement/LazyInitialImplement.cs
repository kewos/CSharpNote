using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.LazyInitial;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class LazyInitialImplement : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            GroupItem.GetByName("A").ToConsole();
            GroupItem.GetByName("B").ToConsole();
            GroupItem.GetByName("C").ToConsole();

            foreach (var fruit in GroupItem.GetAll())
            {
                fruit.ToConsole();
            }
        }
    }
}