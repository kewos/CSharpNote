using System;

namespace CSharpNote.Data.DesignPatternMethod.Implement.BuilderPattern
{
    public class Car
    {
        public string Color { get; private set; }
        public string Description { get; private set; }
        public int Size { get; private set; }
        public DateTime CreateOn { get; private set; }
    }
}