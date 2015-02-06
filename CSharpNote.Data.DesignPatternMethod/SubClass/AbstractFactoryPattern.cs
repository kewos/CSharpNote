using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass
{
    public abstract class AbstractFactoryPattern
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    public class WindowsFactory : AbstractFactoryPattern
    {
        public override AbstractProductA CreateProductA()
        {
            return new WindowProductA();
        }

        public override AbstractProductB CreateProductB()
        {
            return new WindowProductB();
        }
    }

    public class UnixFactory : AbstractFactoryPattern
    {
        public override AbstractProductA CreateProductA()
        {
            return new UnixProductA();
        }

        public override AbstractProductB CreateProductB()
        {
            return new UnixProductB();
        }
    }

    public abstract class AbstractProductA
    {
        public abstract void Display();
    }

    public class UnixProductA : AbstractProductA
    {
        public override void Display()
        {
            Console.WriteLine("UnixProductA : AbstractProductA");
        }
    }

    public class WindowProductA : AbstractProductA
    {
        public override void Display()
        {
            Console.WriteLine("WindowProductA : AbstractProductA");
        }
    }

    public abstract class AbstractProductB
    {
        public abstract void Display();
    }

    public class UnixProductB : AbstractProductB
    {
        public override void Display()
        {
            Console.WriteLine("UnixProductB : AbstractProductB");
        }
    }

    public class WindowProductB : AbstractProductB
    {
        public override void Display()
        {
            Console.WriteLine("WindowProductB : AbstractProductB");
        }
    }
}
