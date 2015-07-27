
namespace CSharpNote.Data.DataStructure.Implement.Buffer
{
    public interface IBuffer<T>
    {
        void Write(T value);
        T Read();
    }
}
