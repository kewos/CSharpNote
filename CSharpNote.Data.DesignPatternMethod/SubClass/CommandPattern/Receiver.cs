namespace CSharpNote.Data.DesignPatternMethod.SubClass.CommandPattern
{
    public class Receiver
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Receiver(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}