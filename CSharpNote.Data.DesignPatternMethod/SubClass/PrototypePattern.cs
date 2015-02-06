using System;
using System.Collections;

namespace CSharpNote.Data.DesignPatternMethod.SubClass
{
    // "Prototype"
    abstract class ColorPrototype
    {
        // Methods
        public abstract ColorPrototype Clone();
    }

    // "ConcretePrototype"
    class Color : ColorPrototype
    {
        // Fields
        private int red, green, blue;

        // Constructors
        public Color(int red, int green, int blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        // Methods
        public override ColorPrototype Clone()
        {
            // Creates a 'shallow copy'
            return (ColorPrototype)this.MemberwiseClone();
        }

        public void Display()
        {
            Console.WriteLine("RGB values are: {0},{1},{2}",
              red, green, blue);
        }
    }

    // Prototype manager
    class ColorManager
    {
        // Fields
        Hashtable colors = new Hashtable();

        // Indexers
        public ColorPrototype this[string name]
        {
            get { return (ColorPrototype)colors[name]; }
            set { colors.Add(name, value); }
        }
    }
}
