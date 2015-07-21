namespace CSharpNote.Data.DesignPatternMethod.Implement.PrototypePattern
{
    public interface IPrototype<T>
    {
        T Clone();
        T DeepClone();
    }
}