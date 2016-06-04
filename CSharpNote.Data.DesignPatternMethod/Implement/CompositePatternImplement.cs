using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.CompositePattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class CompositePatternImplement : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            new CompositeA(new List<IComponent>
            {
                new CompositeB(new List<IComponent>
                {
                    new Leaf(),
                    new Leaf(),
                    new Leaf()
                }),
                new CompositeB(),
                new CompositeB(new List<IComponent>
                {
                    new CompositeA(),
                    new CompositeA(),
                    new CompositeA(new List<IComponent>
                    {
                        new Leaf(),
                        new Leaf(),
                        new Leaf()
                    })
                })
            }).Execute();
        }
    }
}