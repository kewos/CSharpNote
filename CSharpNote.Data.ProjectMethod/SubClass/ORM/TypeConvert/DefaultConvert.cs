namespace CSharpNote.Data.ProjectMethod.SubClass.ORM.TypeConvert
{
    /// <summary>
    /// 預設字串轉字串
    /// </summary>
    public class DefaultConvert : IStringTypeConvert<string>
    {
        public string Convert(string input)
        {
            return input;
        }
    }
}