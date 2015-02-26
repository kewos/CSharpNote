namespace CSharpNote.Data.DesignPatternMethod.SubClass.AbstractFactoryPattern
{
    public class UnixFactory : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new UnixProductA();
        }

        public override AbstractProductB CreateProductB()
        {
            return new UnixProductB();
        }
    }
}