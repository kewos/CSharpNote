using System;

namespace CSharpNote.Data.Project.Implement.ORM.TypeConvert
{
    /// <summary>
    /// 字串轉bool
    /// </summary>
    public class StringToBool : IStringConvert<bool>
    {
        public bool Convert(string input)
        {
            bool value;
            if (bool.TryParse(input, out value))
            {
                return value;
            }
            throw new ArgumentException("Convert fail");
        }
    }
}
