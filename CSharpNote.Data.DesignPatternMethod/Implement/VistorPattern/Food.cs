using System;

namespace CSharpNote.Data.DesignPatternMethod.Implement.VistorPattern
{
    public class Coffee : IFood
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitCoffee(this);
        }

        public void AddSugar()
        {
            Console.Write("add sugar.");
        }

        public void AddMilk()
        {
            Console.Write("add milk.");
        }
    }

    public class Meat : IFood
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitMeat(this);
        }
    }

    public class Vegetable : IFood
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitVegetable(this);
        }
    }
}