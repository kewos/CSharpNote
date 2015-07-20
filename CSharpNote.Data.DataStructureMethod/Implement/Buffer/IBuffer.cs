
namespace CSharpNote.Data.DataStructureMethod.Implement.Buffer
{
    public interface IBuffer<T>
    {
        void Write(T value);
        T Read();
    }
}
