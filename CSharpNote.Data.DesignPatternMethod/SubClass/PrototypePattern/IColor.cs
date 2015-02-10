namespace CSharpNote.Data.DesignPatternMethod.SubClass.PrototypePattern
{
    public interface IColor : IPrototype<IColor>
    {
        void Display();
    }
}