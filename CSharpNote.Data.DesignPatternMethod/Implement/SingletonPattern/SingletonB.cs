namespace CSharpNote.Data.DesignPattern.Implement.SingletonPattern
{
    public class SingletonB
    {
        private static readonly SingletonB instance = new SingletonB();

        static SingletonB()
        {
        }

        public static SingletonB Instance()
        {
            return instance;
        }
    }
}