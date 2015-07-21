namespace CSharpNote.Data.DesignPatternMethod.Implement.PrototypePattern
{
    public interface IColor : IPrototype<IColor>
    {
        void Display();
    }
}