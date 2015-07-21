namespace CSharpNote.Data.DesignPatternMethod.Implement.BridgePattern
{
    public class TriangleBridgeShape : AbstractBridgeShape
    {
        public TriangleBridgeShape(IBridgeColor color)
            : base(color)
        {
        }

        public override string Shape
        {
            get
            {
                return GetType().Name;
            }
        }
    }

    public class CircleBridgeShape : AbstractBridgeShape
    {
        public CircleBridgeShape(IBridgeColor color)
            : base(color)
        {
        }

        public override string Shape
        {
            get
            {
                return GetType().Name;
            }
        }
    }
}