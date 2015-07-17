namespace CSharpNote.Data.ProjectMethod.SubClass.ORM.TypeConvert
{
    /// <summary>
    /// 字串轉換型別介面
    /// </summary>
    /// <typeparam name="TInput">Input Type</typeparam>
    /// <typeparam name="TOutput">Output Type</typeparam>
    public interface IStringTypeConvert<out TOutput> : ITypeConvert<string, TOutput>
    {
    }
}