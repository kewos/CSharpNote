namespace CSharpNote.Data.DesignPatternMethod.Implement.PrototypePattern
{
    public interface IColorManager
    {
        IColor this[string name] { get; set; }
    }
}