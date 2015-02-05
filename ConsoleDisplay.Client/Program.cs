using ConsoleDisplay.Client.Contrasts;

namespace ConsoleDisplay.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            BootStrap.Config().GetInstance<IProjectManager>().Start();
        }
    }
}

