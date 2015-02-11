
namespace CSharpNote.Data.DesignPatternMethod.SubClass
{
    public class SingletonObject<T> where T : class, new()
    {
        private static T instance;

        private SingletonObject()
        {
        }

        public static T Instance()
        {
            if (instance == (T)null)
            {
                instance = new T();
            }
            return instance;
        }
    }
}
