namespace CSharpNote.Data.DesignPattern.Implement.PrototypePattern
{
    public interface IPrototype<T>
    {
        T Clone();
        T DeepClone();
    }
}