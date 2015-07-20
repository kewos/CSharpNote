namespace CSharpNote.Data.ProjectMethod.SubClass.ORM.TypeConvert
{
    /// <summary>
    /// 字串轉float?
    /// </summary>
    public class StringToFloatNullable : IStringConvert<float?>
    {
        public float? Convert(string input)
        {
            float value;
            if (float.TryParse(input, out value))
            {
                return value;
            }
            return null;
        }
    }
}