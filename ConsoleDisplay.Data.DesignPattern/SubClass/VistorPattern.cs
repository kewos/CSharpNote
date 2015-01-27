using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplay.Data.DesignPattern.SubClass
{
    abstract class Visitor
    {
        public abstract void VisitCoffee(Coffee c);
        public abstract void VisitMeat(Meat m);
        public abstract void VisitVegetable(Vegetable v);
    }

    class ZhangSan : Visitor
    {
        public override void VisitCoffee(Coffee c)
        {
            Console.Write( "{0}: Take a cup of {1}, ",this, c);
            c.AddMilk();
            c.AddSugar();
            Console.WriteLine();
        }

        public override void VisitVegetable(Vegetable v)
        {
            Console.WriteLine( "{0}: Take some {1}", this, v );
        }

        public override void VisitMeat(Meat m)
        {
            Console.WriteLine( "I don't want any meat!");
        }
    }

    class LiSi : Visitor
    {
        public override void VisitCoffee(Coffee c)
        {
            Console.Write( "{0}: Take a cup of {1}, ",this, c);
            c.AddSugar();
            Console.WriteLine();
        }

        public override void VisitVegetable(Vegetable v)
        {
            Console.WriteLine( "{0}: Take some {1}", this, v );
        }

        public override void VisitMeat(Meat m)
        {
            Console.WriteLine( "{0}: Take some {1}", this, m );
        }
    }

    abstract class Food
    { 
        abstract public void Accept( Visitor visitor );
    }

    class Coffee: Food  
    {
        override public void Accept( Visitor visitor )
        {
          visitor.VisitCoffee( this );
        }

        public void AddSugar()
        {
           Console.Write("add sugar. ");   
        }

        public void AddMilk()
        {
           Console.Write("add milk. ");   
        }
    }

    class Meat: Food  
    {
          override public void Accept( Visitor visitor )
          {
            visitor.VisitMeat( this );
          }
    }

    class Vegetable: Food  
    {

          override public void Accept( Visitor visitor )
          {
            visitor.VisitVegetable( this );
          }
    }

    class BuffetDinner
    {
        private System.Collections.ArrayList elements = new System.Collections.ArrayList();

        public void Attach(Food element)
        {
            elements.Add(element);
        }

        public void Detach(Food element)
        {
            elements.Remove(element);
        }

        public void Accept(Visitor visitor)
        {
            foreach (Food f in elements)
                f.Accept(visitor);
        }
    }
}
