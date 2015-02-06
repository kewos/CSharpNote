
namespace CSharpNote.Data.DataStructureMethod.SubClass.Buffer
{
    public interface IBuffer<T>
    {
        void Write(T value);
        T Read();
    }
}
