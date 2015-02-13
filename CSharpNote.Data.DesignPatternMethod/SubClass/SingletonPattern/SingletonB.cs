namespace CSharpNote.Data.DesignPatternMethod.SubClass.SingletonPattern
{
    public class SingletonB
    {
        private static SingletonB instance = new SingletonB();

        static SingletonB()
        {
        }

        public static SingletonB Instance()
        {
            return instance;
        }
    }
}