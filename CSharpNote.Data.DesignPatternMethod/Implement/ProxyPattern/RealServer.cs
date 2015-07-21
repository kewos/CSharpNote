namespace CSharpNote.Data.DesignPatternMethod.Implement.ProxyPattern
{
    public class RealServer : IServer
    {
        public string DoAction()
        {
            return GetType().Name;
        }
    }
}