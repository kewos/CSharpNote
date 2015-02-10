using System;
using System.Collections.Generic;

namespace CSharpNote.Data.DesignPatternMethod.SubClass
{
    public interface IVisitor
    {
        void VisitCoffee(Coffee coffee);
        void VisitMeat(Meat meet);
        void VisitVegetable(Vegetable vegetable);
    }

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
            Console.WriteLine( "I don't want any meat!");
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

    public interface IFood
    { 
        void Accept(IVisitor visitor);
    }

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

    public class BuffetDinner
    {
        private readonly IList<IFood> elements;

        public BuffetDinner()
        {
            elements = new List<IFood>();
        }

        public void Attach(IFood element)
        {
            elements.Add(element);
        }

        public void Detach(IFood element)
        {
            elements.Remove(element);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (IFood food in elements)
            {
                food.Accept(visitor);
            }
        }
    }
}
