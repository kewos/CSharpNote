using System;

namespace CSharpNote.Data.DesignPatternMethod.Implement.FlyweightPattern
{
    public class FlyWeightObjectA : IFlyWeightObject
    {
        private readonly int id;

        public FlyWeightObjectA(int label)
        {
            this.id = label;
        }

        public void Execute()
        {
            Console.WriteLine("id:{0} hashcode:{1}", id, GetHashCode());
        }
    }
}