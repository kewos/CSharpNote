namespace CSharpNote.Data.DesignPattern.Implement.PrototypePattern
{
    public interface IColorManager
    {
        IColor this[string name] { get; set; }
    }
}