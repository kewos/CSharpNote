using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.Aop;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class AspectOrientProgram : AbstractExecuteModule
    {
        /// <summary>
        ///     觀注點切入的設計方式
        ///     常用於input validation, log等功能
        ///     可讓程式更符合單一責則的設計原則
        /// </summary>
        [MarkedItem]
        public override void Execute()
        {
            AOP.Registry.Join(
                typeof(Actor).GetConstructors().First(),
                typeof(Concern).GetConstructors().First()
                );
            var actor = (IActor)AOP.Factory.Create<Actor>("");

            Console.WriteLine(actor.Name);
            Console.WriteLine(new Actor("adabcbc").Name);
        }
    }
}