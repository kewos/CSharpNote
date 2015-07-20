using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.PrototypePattern
{
    [Serializable]
    public class Color : IColor
    {
        private readonly int red;
        private readonly int green;
        private readonly int blue;

        public Color(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        public IColor Clone()
        {
            return MemberwiseClone() as IColor;
        }

        public IColor DeepClone()
        {
            return DeepClone();
        }

        public void Display()
        {
            Console.WriteLine("R:{0} G:{1} B:{2}", red, green, blue);
        }
    }
}