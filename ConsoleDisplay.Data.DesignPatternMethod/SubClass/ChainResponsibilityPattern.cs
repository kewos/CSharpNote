using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplay.Data.DesignPatternMethod.SubClass
{
    public abstract class Chain
    {
        protected Chain upChain;

        public void setUpChain(Chain chain)
        {
            this.upChain = chain;
        }

        abstract public void RequestChain(int lv);
    }

    public class ChainA : Chain
    {
        public override void RequestChain(int lv)
        {
            if (lv >= 1 && lv < 3)
            {
                Console.WriteLine("you are level A");
            }
            else
            {
                upChain.RequestChain(lv);
            }
        }
    }

    public class ChainB : Chain
    {
        public override void RequestChain(int lv)
        {
            if (lv >= 3 && lv < 5)
            {
                Console.WriteLine("you are level B");
            }
            else
            {
                upChain.RequestChain(lv);
            }
        }
    }

    public class ChainC : Chain
    {
        public override void RequestChain(int lv)
        {
            if (lv >= 5 && lv < 7)
            {
                Console.WriteLine("you are level A");
            }
            else
            {
                upChain.RequestChain(lv);
            }
        }
    }

    public class ChainD : Chain
    {
        public override void RequestChain(int lv)
        {
            if (lv >= 7)
            {
                Console.WriteLine("you are level D");
            }
            else
            {
                upChain.RequestChain(lv);
            }
        }
    }

}
