namespace CSharpNote.Data.DesignPattern.Implement.BuilderPattern
{
    public interface IBuilder<T>
        where T : class
    {
        T Create();
    }
}