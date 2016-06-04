using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.DecoratorPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class DecoratorPatternImplement : AbstractExecuteModule
    {
        /// <summary>
        ///     著重於動態擴充方法功能
        /// </summary>
        [MarkedItem]
        public override void Execute()
        {
            new DecoratorB(new DecoratorA(new ConcreteComponentA())).Operation().ToConsole();
        }
    }
}