namespace CSharpNote.Data.DesignPatternMethod.Implement.DecoratorPattern
{
    public class ConcreteComponentA : IComponent
    {
        public string Operation()
        {
            return GetType().Name;
        }
    }
}