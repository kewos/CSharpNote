namespace CSharpNote.Data.DesignPatternMethod.SubClass.DecoratorPattern
{
    public class DecoratorA : AbstractDecorator
    {
        public DecoratorA(IComponent component)
            : base(component)
        {
        }

        public override string Operation()
        {
            return GetType().Name + component.Operation();
        }
    }
    
    public class DecoratorB : AbstractDecorator
    {
        public DecoratorB(IComponent component)
            : base(component)
        {
        }

        public override string Operation()
        {
            return GetType().Name + component.Operation();
        }
    }
}