namespace CSharpNote.Data.DesignPatternMethod.SubClass.PrototypePattern
{
    public interface IPrototype<T>
    {
        T Clone();
        T DeepClone();
    }
}