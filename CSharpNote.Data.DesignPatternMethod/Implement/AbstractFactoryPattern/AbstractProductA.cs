using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.AbstractFactoryPattern
{
    public abstract class AbstractProductA
    {
        public abstract void Display();
    }

    public class UnixProductA : AbstractProductA
    {
        public override void Display()
        {
            Console.WriteLine("{0} : {1}", GetType().Name, "AbstractProductA");
        }
    }

    public class WindowProductA : AbstractProductA
    {
        public override void Display()
        {
            Console.WriteLine("{0} : {1}", GetType().Name, "AbstractProductA");
        }
    }
}