using System;

namespace CSharpNote.Data.DesignPattern.Implement.SpecificationPattern
{
    public class Band
    {
        public Band(string name, BandKind kind, Country country)
        {
            BandName = name;
            BandKind = kind;
            Country = country;
        }

        public string BandName { get; set; }
        public BandKind BandKind { get; set; }
        public Country Country { get; set; }

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
        Uk,
        Gereman,
        Australia
    }
}