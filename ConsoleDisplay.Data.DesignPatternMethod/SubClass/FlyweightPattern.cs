using System;
using System.Collections.Generic;

namespace ConsoleDisplay.Data.DesignPatternMethod.SubClass
{
    public interface IButton
    {
        void Draw();
    }

    public class FlyweightButton : IButton
    {
        private readonly int label;
        private int couter;

        public FlyweightButton(int label)
        {
            couter = 0;
            this.label = label;
        }

        public void Draw() 
        {
            Console.WriteLine("label:{0} couter:{1} hashcode:{2}", label, ++couter, GetHashCode());
        }
    }

    public class FlyweightButtonFactory
    {
        private readonly IDictionary<int, IButton> pool;

        public FlyweightButtonFactory()
        {
            pool = new Dictionary<int, IButton>();
        }

        public IButton GetFlyweightButton(int label)
        {
            if (!pool.ContainsKey(label))
            {
                pool.Add(label, new FlyweightButton(label));
            }
            return pool[label];
        }

    }
}