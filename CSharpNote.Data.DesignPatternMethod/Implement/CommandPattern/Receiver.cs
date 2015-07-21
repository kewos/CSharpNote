namespace CSharpNote.Data.DesignPatternMethod.Implement.CommandPattern
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