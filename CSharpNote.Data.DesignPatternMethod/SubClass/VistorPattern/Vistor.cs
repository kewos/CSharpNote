using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.VistorPattern
{
    public class VistorA : IVisitor
    {
        public void VisitCoffee(Coffee coffee)
        {
            Console.Write("{0}: Take a cup of {1}, ", GetType().Name, coffee.GetType().Name);
            coffee.AddMilk();
            coffee.AddSugar();
            Console.WriteLine();
        }

        public void VisitVegetable(Vegetable vegetable)
        {
            Console.WriteLine("{0}: Take some {1}", GetType().Name, vegetable.GetType().Name);
        }

        public void VisitMeat(Meat meat)
        {
            Console.WriteLine("I don't want any meat!");
        }
    }

    public class VistorB : IVisitor
    {
        public void VisitCoffee(Coffee coffee)
        {
            Console.Write("{0}: Take a cup of {1}, ", GetType().Name, coffee.GetType().Name);
            coffee.AddSugar();
            Console.WriteLine();
        }

        public void VisitVegetable(Vegetable vegetable)
        {
            Console.WriteLine("{0}: Take some {1}", GetType().Name, vegetable.GetType().Name);
        }

        public void VisitMeat(Meat meat)
        {
            Console.WriteLine("{0}: Take some {1}", GetType().Name, meat.GetType().Name);
        }
    }
}