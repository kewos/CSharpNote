namespace CSharpNote.Core.Contracts
{
    public interface IMethodManager
    {
        /// <summary>
        /// 執行
        /// </summary>
        void Start(IMethodRepository repository);
    }
}
