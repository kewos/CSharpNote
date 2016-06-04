using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.StatePattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class StatetPatternImplement : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var context = new Context(new StateA());
            Enumerable.Range(0, 10).ForEach(n => context.Execute());
        }
    }
}