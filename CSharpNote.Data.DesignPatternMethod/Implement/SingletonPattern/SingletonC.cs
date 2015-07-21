namespace CSharpNote.Data.DesignPatternMethod.Implement.SingletonPattern
{
    public class SingletonC
    {
        private static SingletonC instance;

        private SingletonC()
        {
        }

        public static SingletonC Instance()
        {
            if (instance == null)
            {
                instance = new SingletonC();
            }
            return instance;
        }
    }
}