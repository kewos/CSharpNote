namespace CSharpNote.Data.DesignPatternMethod.SubClass.AdapterPattern
{
    public class Robot : IMachine
    {
        public string Do()
        {
            return GetType().Name;
        }
    }
}