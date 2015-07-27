namespace CSharpNote.Data.DesignPattern.Implement.DecoratorPattern
{
    public class ConcreteComponentA : IComponent
    {
        public string Operation()
        {
            return GetType().Name;
        }
    }
}