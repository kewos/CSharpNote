namespace CSharpNote.Data.DesignPatternMethod.SubClass.DecoratorPattern
{
    public class ConcreteComponentA : IComponent
    {
        public string Operation()
        {
            return GetType().Name;
        }
    }
}