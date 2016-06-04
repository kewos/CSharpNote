using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.ProxyPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class ProxyPatternImplement : AbstractExecuteModule
    {
        /// <summary>
        ///     ProxyServer一開始就指定指向哪個RealServer
        /// </summary>
        [MarkedItem]
        public override void Execute()
        {
            new ProxyServer().DoAction().ToConsole();
        }
    }
}