namespace CSharpNote.Data.DesignPattern.Implement.ProxyPattern
{
    public class RealServer : IServer
    {
        public string DoAction()
        {
            return GetType().Name;
        }
    }
}