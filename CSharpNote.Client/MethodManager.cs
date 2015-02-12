using CSharpNote.Common.Extendsions;
using CSharpNote.Core.Contracts;

namespace CSharpNote.Client
{
    public class MethodManager : IMethodManager
    {
        public void Start(IMethodRepository repository)
        {
            repository.GetMethodNames()
                .SelectAndShowOnConsole(index => Excute(index, repository));
        }

        #region private method
        private void Excute(int index, IMethodRepository repository)
        {
            repository[index].Invoke(repository, null);
        }
        #endregion
    }
}
