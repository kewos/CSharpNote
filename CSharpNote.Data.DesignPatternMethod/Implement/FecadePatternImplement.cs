using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.FecadePattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class FecadePatternImplement : AbstractExecuteModule
    {
        /// <summary>
        ///     FecadePattern 用於隱藏子系統的細節
        ///     但子系統會跟Fecade造成耦合
        /// </summary>
        [MarkedItem]
        public override void Execute()
        {
            var fecade = new Fecade();
            fecade.MethodA().ToConsole();
            fecade.MethodB().ToConsole();
            fecade.MethodC().ToConsole();
        }
    }
}