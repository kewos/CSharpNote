using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.FlyweightPattern
{
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
}