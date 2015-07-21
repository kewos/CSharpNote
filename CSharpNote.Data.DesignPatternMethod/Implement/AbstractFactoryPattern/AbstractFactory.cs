namespace CSharpNote.Data.DesignPatternMethod.Implement.AbstractFactoryPattern
{
    public abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }
}