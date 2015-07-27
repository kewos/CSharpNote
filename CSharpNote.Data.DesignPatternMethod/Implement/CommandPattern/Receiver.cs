namespace CSharpNote.Data.DesignPattern.Implement.CommandPattern
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