using System;

namespace CSharpNote.Data.ProjectMethod.Implement.ORM.TypeConvert
{
    /// <summary>
    /// 字串轉Int
    /// </summary>
    public class StringToInt : IStringConvert<int>
    {
        public int Convert(string input)
        {
            int value;
            if (int.TryParse(input, out value))
            {
                return value;
            }
            throw new ArgumentException("Convert fail");
        }
    }
}