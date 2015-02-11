namespace CSharpNote.Data.DesignPatternMethod.SubClass.FecadePattern
{
    public class SubClassA
    {
        public string DoSomeThing()
        {
            return GetType().Name;
        }
    }

    public class SubClassB
    {
        public string DoSomeThing()
        {
            return GetType().Name;
        }
    }
}