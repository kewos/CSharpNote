using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.FlyweightPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class FlyweightPatternImplement : AbstractExecuteModule
    {
        /// <summary>
        ///     Intent:
        ///     The intent of this pattern is to use sharing to support a large number of objects
        ///     that have part of their internal state in common where the other part of state can
        ///     vary.
        /// </summary>
        [MarkedItem]
        public override void Execute()
        {
            var factory = new FlyweightFactory();
            Enumerable.Range(1, 30)
                .Select(n => factory.Get(n % 3))
                .ForEach(obj => obj.Execute());
        }
    }
}