
namespace CSharpNote.Data.DesignPattern.Implement.Aop
{
    interface IConcern<T>
    {
        T This { get; }
    }

    public class Concern : IConcern<Actor>
    {
        public Actor This { get; set; }

        public Concern(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "Null String";
            }

            This = new Actor(name);
        }
    }
}
