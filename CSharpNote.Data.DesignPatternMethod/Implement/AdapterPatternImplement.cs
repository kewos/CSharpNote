using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.AdapterPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class AdapterPatternImplement : AbstractExecuteModule
    {
        /// <summary>
        ///     convert the interface of a class into another interface
        /// </summary>
        [MarkedItem]
        public override void Execute()
        {
            new List<IAnimal>
            {
                new DogAdaptor(new Robot()),
                new CatAdaptor(new Robot()),
                new Monkey()
            }.ForEach(animal => animal.Run());
        }
    }
}