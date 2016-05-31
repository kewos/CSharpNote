using CSharpNote.Common.Extensions;
using CSharpNote.Common.Helper;
using CSharpNote.Core.Contracts;

namespace CSharpNote.Client
{
    public class CSharpNotePresenter : ICSharpNotePresenter
    {
        private readonly ICSharperNoteService cSharperNoteService;
        private readonly ICSharpNoteView cSharpNoteView;

        public CSharpNotePresenter(ICSharpNoteView cSharpNoteView, ICSharperNoteService cSharperNoteService)
        {
            this.cSharpNoteView = cSharpNoteView.ValidationNotNull();
            this.cSharperNoteService = cSharperNoteService.ValidationNotNull();
        }

        public void Start()
        {
            ShowRepository();
        }

        #region Private Method

        private void ShowRepository()
        {
            var resource = cSharperNoteService.GetRepositoryNames();

            cSharpNoteView.SelectAndShowOnConsole(resource, index => ShowMethodInfo(cSharperNoteService[index]));
        }

        private void ShowMethodInfo(IMethodRepository repository)
        {
            var resource = repository.GetMethodNames();

            cSharpNoteView.SelectAndShowOnConsole(resource, index => InvokeMethodInfo(index, repository));
        }

        private void InvokeMethodInfo(int index, IMethodRepository repository)
        {
            FastInvokeHelper.Create(repository[index])(repository, null);
        }

        #endregion
    }
}