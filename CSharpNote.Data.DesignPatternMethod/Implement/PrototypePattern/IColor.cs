namespace CSharpNote.Data.DesignPattern.Implement.PrototypePattern
{
    public interface IColor : IPrototype<IColor>
    {
        void Display();
    }
}