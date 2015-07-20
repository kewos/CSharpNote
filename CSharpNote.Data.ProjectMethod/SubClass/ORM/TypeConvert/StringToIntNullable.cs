namespace CSharpNote.Data.ProjectMethod.SubClass.ORM.TypeConvert
{
    /// <summary>
    /// 字串轉Int?
    /// </summary>
    public class StringToIntNullable : IStringConvert<int?>
    {
        public int? Convert(string input)
        {
            int value;
            if (int.TryParse(input, out value))
            {
                return value;
            }
            return null;
        }
    }
}