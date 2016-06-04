using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.VistorPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class VistorPatternImplement : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            var buffetDinner = new BuffetDinner();
            buffetDinner.Attach(new Coffee());
            buffetDinner.Attach(new Vegetable());
            buffetDinner.Attach(new Meat());

            var vistorA = new VistorA();
            var vistorB = new VistorB();

            buffetDinner.Accept(vistorA);
            Console.WriteLine("----------------------");
            buffetDinner.Accept(vistorB);
        }
    }
}