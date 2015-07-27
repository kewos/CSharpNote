namespace CSharpNote.Data.DesignPattern.Implement.AbstractFactoryPattern
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