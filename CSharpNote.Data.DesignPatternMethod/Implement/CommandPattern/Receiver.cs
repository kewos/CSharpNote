namespace CSharpNote.Data.DesignPattern.Implement.CommandPattern
{
    public class Receiver
    {
        public Receiver(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }
}