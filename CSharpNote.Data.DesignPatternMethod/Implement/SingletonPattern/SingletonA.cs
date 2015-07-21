namespace CSharpNote.Data.DesignPatternMethod.Implement.SingletonPattern
{
    public class SingletonA
    {
        private static SingletonA instance;
        private static object lockobject = new object();

        private SingletonA()
        {
        }

        public static SingletonA Instance()
        {
            if (instance == null)
            {
                lock (lockobject)
                {
                    if (instance == null)
                    {
                        instance = new SingletonA();
                    }
                }
            }
            return instance;
        }
    }
}