using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.BuilderPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class BuilderPatternImplement : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var builder = new CarBuilder()
                .Add("Color", "Red")
                .Add("Description", "Test")
                .Add("Size", 10)
                .Add("CreateOn", DateTime.Now);

            var instance = builder.Create();
            string.Format("{0}{1}{2}{3}", instance.Color, instance.Description, instance.Size, instance.CreateOn)
                .ToConsole();

            Enumerable.Range(1, 100)
                .Select(x => builder.Create().GetHashCode())
                .Distinct()
                .Count()
                .ToConsole();
        }
    }
}