using System;

namespace CSharpNote.Data.DesignPatternMethod.Implement.SpecificationPattern
{
    public class Band
    {
        public string BandName { get; set; }
        public BandKind BandKind { get; set; }
        public Country Country { get; set; }

        public Band(string name, BandKind kind, Country country)
        {
            BandName = name;
            BandKind = kind;
            Country = country;
        }

        public void Description()
        {
            Console.WriteLine("Band:{0} is {1} Band From {2}", BandName, BandKind, Country);
        }
    }

    public enum BandKind
    {
        IndustryMetal,
        HardCore,
        BritPop,
        ClassRock,
        Grunge,
        Punk
    }

    public enum Country
    {
        UK,
        Gereman,
        Australia
    }
}