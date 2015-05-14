using CSharpNote.Core.Contracts;

namespace CSharpNote.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Bootstrap.Config().GetInstance<ICSharpNotePresenter>().Start();
        }
    }
}

