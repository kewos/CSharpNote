namespace CSharpNote.Data.DesignPattern.Implement.ProxyPattern
{
    public class ProxyServer : IServer
    {
        private readonly IServer server;

        public ProxyServer()
        {
            server = new RealServer();
        }

        public string DoAction()
        {
            return GetType().Name + server.DoAction();
        }
    }
}