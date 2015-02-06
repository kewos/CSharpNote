using CSharpNote.Core.Contracts;

namespace CSharpNote.Client.Contrasts
{
    public interface IMethodManager
    {
        /// <summary>
        /// 呈現方法清單
        /// </summary>
        /// <param name="repository">執行的方案</param>
        void Start(IMethodRepository repository);
    }
}
