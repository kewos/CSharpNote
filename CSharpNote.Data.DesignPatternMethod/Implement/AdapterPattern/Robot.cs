namespace CSharpNote.Data.DesignPattern.Implement.AdapterPattern
{
    public class Robot : IMachine
    {
        public string Do()
        {
            return GetType().Name;
        }
    }
}