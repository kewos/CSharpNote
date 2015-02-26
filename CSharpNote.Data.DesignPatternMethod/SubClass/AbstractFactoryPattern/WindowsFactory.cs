namespace CSharpNote.Data.DesignPatternMethod.SubClass.AbstractFactoryPattern
{
    public class WindowsFactory : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new WindowProductA();
        }

        public override AbstractProductB CreateProductB()
        {
            return new WindowProductB();
        }
    }
}