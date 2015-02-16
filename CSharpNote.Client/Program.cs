using CSharpNote.Core.Contracts;

namespace CSharpNote.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            BootStrap.Config().GetInstance<ICSharpNotePresenter>().Start();
        }
    }
}

