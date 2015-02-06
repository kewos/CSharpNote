
namespace CSharpNote.Data.DesignPatternMethod.SubClass
{
    public class GenericSingleton<T> where T : class, new()
    {
        private static T instance;

        private GenericSingleton()
        {
        }

        public static T Instance()
        {
            if (instance == (T)null) 
                instance = new T();
            return instance;
        }
    }
}
