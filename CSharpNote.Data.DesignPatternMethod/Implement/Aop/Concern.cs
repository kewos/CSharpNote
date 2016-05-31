namespace CSharpNote.Data.DesignPattern.Implement.Aop
{
    internal interface IConcern<T>
    {
        T This { get; }
    }

    public class Concern : IConcern<Actor>
    {
        public Concern(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "Null String";
            }

            This = new Actor(name);
        }

        public Actor This { get; set; }
    }
}