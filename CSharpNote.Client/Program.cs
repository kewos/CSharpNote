using CSharpNote.Core.Contracts;

namespace CSharpNote.Client
{
    internal class Program
    {
        private static void Main()
        {
            Bootstrap.Config().GetInstance<ICSharpNotePresenter>().Start();
        }
    }
}