using CSharpNote.Common.Extendsions;
using CSharpNote.Core.Contracts;

namespace CSharpNote.Client
{
    public class CSharpNotePresenter : ICSharpNotePresenter
    {
        private readonly ICSharpNoteView cSharpNoteView;
        private readonly ICSharperNoteService cSharperNoteService;

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

            cSharpNoteView.SelectAndShowOnConsole(resource, index => InvokeRepository(index));
        }

        private void InvokeRepository(int index)
        {
            ShowMethodInfo(cSharperNoteService[index]);
        }

        private void ShowMethodInfo(IMethodRepository repository)
        {
            var resource = repository.ValidationNotNull().GetMethodNames();

            cSharpNoteView.SelectAndShowOnConsole(resource, index => InvokeMethodInfo(index, repository));
        }

        private void InvokeMethodInfo(int index, IMethodRepository repository)
        {
            repository[index].Invoke(repository, null);
        }
        #endregion
    }
}
