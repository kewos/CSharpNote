using System;

namespace CSharpNote.Data.DesignPattern.Implement.AbstractFactoryPattern
{
    public abstract class AbstractProductB
    {
        public abstract void Display();
    }

    public class UnixProductB : AbstractProductB
    {
        public override void Display()
        {
            Console.WriteLine("{0} : {1}", GetType().Name, "AbstractProductB");
        }
    }

    public class WindowProductB : AbstractProductB
    {
        public override void Display()
        {
            Console.WriteLine("{0} : {1}", GetType().Name, "AbstractProductB");
        }
    }
}