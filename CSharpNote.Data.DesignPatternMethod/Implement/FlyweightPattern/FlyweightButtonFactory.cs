using System.Collections.Generic;

namespace CSharpNote.Data.DesignPatternMethod.Implement.FlyweightPattern
{
    public class FlyweightFactory
    {
        private readonly IDictionary<int, IFlyWeightObject> pool;

        public FlyweightFactory()
        {
            pool = new Dictionary<int, IFlyWeightObject>();
        }

        public IFlyWeightObject Get(int label)
        {
            if (!pool.ContainsKey(label))
            {
                pool.Add(label, new FlyWeightObjectA(label));
            }
            return pool[label];
        }
    }
}