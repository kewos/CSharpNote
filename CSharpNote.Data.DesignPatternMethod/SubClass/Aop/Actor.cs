
namespace CSharpNote.Data.DesignPatternMethod.SubClass.Aop
{
    interface IActor
    {
        string Name { get; set; }
    }

    public class Actor : IActor
    {
        public string Name { get; set; }
        public Actor(string name)
        {
            this.Name = name;
        }
    }
}
