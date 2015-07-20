using System;

namespace CSharpNote.Data.ProjectMethod.Implement.ORM.TypeConvert
{
    /// <summary>
    /// 字串轉DateTime?
    /// </summary>
    public class StringToDateTimeNullable : IStringConvert<DateTime?>
    {
        public DateTime? Convert(string input)
        {
            DateTime value;
            if (DateTime.TryParse(input, out value))
            {
                return value;
            }
            return null;
        }
    }
}