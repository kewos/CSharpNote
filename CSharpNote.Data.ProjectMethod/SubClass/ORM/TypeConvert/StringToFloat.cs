using System;

namespace CSharpNote.Data.ProjectMethod.SubClass.ORM.TypeConvert
{
    /// <summary>
    /// 字串轉float
    /// </summary>
    public class StringToFloat : IStringConvert<float>
    {
        public float Convert(string input)
        {
            float value;
            if (float.TryParse(input, out value))
            {
                return value;
            }
            throw new ArgumentException("Convert fail");
        }
    }
}