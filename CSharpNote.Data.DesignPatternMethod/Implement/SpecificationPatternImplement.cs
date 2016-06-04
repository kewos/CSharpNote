using System;
using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.SpecificationPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class SpecificationPatternImplement : AbstractExecuteModule
    {
        [AopTarget(
            "http://www.codeproject.com/Articles/670115/Specification-pattern-in-Csharp",
            "http://en.wikipedia.org/wiki/Specification_pattern#mediaviewer/File:Specification_UML_v2.png")]
        public override void Execute()
        {
            var bands = new List<Band>
            {
                new Band("AC/DC", BandKind.HardCore, Country.Australia),
                new Band("Rammstein", BandKind.IndustryMetal, Country.Gereman),
                new Band("PinkFloyd", BandKind.ClassRock, Country.Uk),
                new Band("TheVerve", BandKind.BritPop, Country.Uk),
                new Band("Nirvana", BandKind.Grunge, Country.Uk),
                new Band("Queen", BandKind.ClassRock, Country.Uk),
                new Band("SexPistals", BandKind.Punk, Country.Uk)
            };

            ISpecification<Band> ukExpSpec =
                new ExpressionSpecification<Band>(band => band.Country == Country.Uk);
            ISpecification<Band> australiaExpSpec =
                new ExpressionSpecification<Band>(band => band.Country == Country.Australia);
            ISpecification<Band> germanExpSpec =
                new ExpressionSpecification<Band>(band => band.Country == Country.Gereman);

            new ExpressionSpecification<Band>(band => band.BandKind == BandKind.BritPop);
            ISpecification<Band> classRockExpSpec =
                new ExpressionSpecification<Band>(band => band.BandKind == BandKind.ClassRock);

            Console.WriteLine("================Search:UK Band");
            bands.FindAll(band => ukExpSpec.IsSatisfiedBy(band))
                .ForEach(band => band.Description());

            Console.WriteLine("================Search:Australia Band");
            bands.FindAll(band => australiaExpSpec.IsSatisfiedBy(band))
                .ForEach(band => band.Description());

            Console.WriteLine("================Search:Gereman Band");
            bands.FindAll(band => germanExpSpec.IsSatisfiedBy(band))
                .ForEach(band => band.Description());

            Console.WriteLine("================Search:UK Or ClassRock");
            var ukOrClassRockExpSpect = ukExpSpec.Or(classRockExpSpec);
            bands.FindAll(band => ukOrClassRockExpSpect.IsSatisfiedBy(band))
                .ForEach(band => band.Description());
        }
    }
}