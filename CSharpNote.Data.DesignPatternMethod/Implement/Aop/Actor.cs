namespace CSharpNote.Data.DesignPattern.Implement.Aop
{
    internal interface IActor
    {
        string Name { get; set; }
    }

    public class Actor : IActor
    {
        public Actor(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}