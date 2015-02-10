namespace CSharpNote.Data.DesignPatternMethod.SubClass.PrototypePattern
{
    public interface IColorManager
    {
        IColor this[string name] { get; set; }
    }
}