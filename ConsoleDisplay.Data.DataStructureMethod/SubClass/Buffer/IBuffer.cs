
namespace ConsoleDisplay.Data.DataStructureMethod.SubClass
{
    public interface IBuffer<T>
    {
        void Write(T value);
        T Read();
    }
}
