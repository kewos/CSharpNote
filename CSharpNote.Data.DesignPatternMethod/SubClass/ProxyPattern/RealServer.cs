namespace CSharpNote.Data.DesignPatternMethod.SubClass.ProxyPattern
{
    public class RealServer : IServer
    {
        public string DoAction()
        {
            return GetType().Name;
        }
    }
}