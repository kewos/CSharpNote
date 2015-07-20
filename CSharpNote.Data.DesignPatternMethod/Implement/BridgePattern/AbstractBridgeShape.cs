using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.BridgePattern
{
    public abstract class AbstractBridgeShape : IBridgeShape
    {
        private readonly IBridgeColor color;

        protected AbstractBridgeShape(IBridgeColor color)
        {
            this.color = color;
        }

        public abstract string Shape { get; }

        public void Display()
        {
            Console.WriteLine("shape:{0} color:{1}", Shape, color.Color);
        }
    }
}