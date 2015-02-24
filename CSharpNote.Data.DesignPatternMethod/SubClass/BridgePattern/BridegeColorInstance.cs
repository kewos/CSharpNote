namespace CSharpNote.Data.DesignPatternMethod.SubClass.BridgePattern
{
    public class RedBridgeColor : IBridgeColor
    {
        public string Color
        {
            get
            {
                return GetType().Name;
            }
        }
    }

    public class YellowBridgeColor : IBridgeColor
    {
        public string Color
        {
            get
            {
                return GetType().Name;
            }
        }
    }
}