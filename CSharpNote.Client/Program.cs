using CSharpNote.Core.Contracts;

namespace CSharpNote.Client
{
    class Program
    {
        static void Main()
        {
            Bootstrap.Config().GetInstance<ICSharpNotePresenter>().Start();
        }
    }
}

