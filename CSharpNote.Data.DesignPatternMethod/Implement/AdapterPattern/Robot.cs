namespace CSharpNote.Data.DesignPatternMethod.Implement.AdapterPattern
{
    public class Robot : IMachine
    {
        public string Do()
        {
            return GetType().Name;
        }
    }
}