namespace CSharpNote.Data.ProjectMethod.Implement.ORM.TypeConvert
{
    /// <summary>
    /// 型別轉換介面
    /// </summary>
    /// <typeparam name="TInput">Input Type</typeparam>
    /// <typeparam name="TOutput">Output Type</typeparam>
    public interface ITypeConvert<in TInput, out TOutput>
    {
        TOutput Convert(TInput input);
    }
}