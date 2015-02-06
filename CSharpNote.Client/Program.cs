using CSharpNote.Client.Contrasts;

namespace CSharpNote.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            BootStrap.Config().GetInstance<IProjectManager>().Start();
        }
    }
}

