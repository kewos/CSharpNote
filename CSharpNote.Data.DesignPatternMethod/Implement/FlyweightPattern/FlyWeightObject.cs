using System;

namespace CSharpNote.Data.DesignPattern.Implement.FlyweightPattern
{
    public class FlyWeightObjectA : IFlyWeightObject
    {
        private readonly int id;

        public FlyWeightObjectA(int label)
        {
            id = label;
        }

        public void Execute()
        {
            Console.WriteLine("id:{0} hashcode:{1}", id, GetHashCode());
        }
    }
}