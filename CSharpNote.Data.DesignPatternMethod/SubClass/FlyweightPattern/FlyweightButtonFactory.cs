using System.Collections.Generic;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.FlyweightPattern
{
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