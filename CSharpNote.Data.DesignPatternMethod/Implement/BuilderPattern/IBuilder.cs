
namespace CSharpNote.Data.DesignPatternMethod.Implement.BuilderPattern
{
    public interface IBuilder<T>
        where T : class
    {
        T Create();
    } 
}