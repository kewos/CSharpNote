namespace CSharpNote.Data.ProjectMethod.SubClass.ORM.TypeConvert
{
    /// <summary>
    /// 字串轉bool?
    /// </summary>
    public class StringToBoolNullable : IStringTypeConvert<bool?>
    {
        public bool? Convert(string input)
        {
            bool value;
            if (bool.TryParse(input, out value))
            {
                return value;
            }
            return null;
        }
    }
}