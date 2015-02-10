using System;
using System.Collections.Generic;

namespace CSharpNote.Data.DesignPatternMethod.SubClass
{
    public interface IColorPrototype<T>
    {
        T Clone();
    }

    public interface IColor : IColorPrototype<IColor>
    {
        void Display();
    }

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

        public void Display()
        {
            Console.WriteLine("R:{0} G:{1} B:{2}", red, green, blue);
        }
    }

    public interface IColorManager
    {
        IColor this[string name] { get; set; }
    }

    public class ColorManager : IColorManager
    {
        private readonly Dictionary<string, IColor> colors;

        public ColorManager()
        {
            colors = new Dictionary<string,IColor>();
        }

        public IColor this[string name]
        {
            get
            {
                return colors[name];
            }
            set
            {
                colors.Add(name, value);
            }
        }
    }
}
