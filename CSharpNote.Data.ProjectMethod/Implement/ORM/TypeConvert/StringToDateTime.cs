using System;

namespace CSharpNote.Data.Project.Implement.ORM.TypeConvert
{
    /// <summary>
    ///     字串轉DateTime
    /// </summary>
    public class StringToDateTime : IStringConvert<DateTime>
    {
        public DateTime Convert(string input)
        {
            DateTime value;
            if (DateTime.TryParse(input, out value))
            {
                return value;
            }
            throw new ArgumentException("Convert fail");
        }
    }
}