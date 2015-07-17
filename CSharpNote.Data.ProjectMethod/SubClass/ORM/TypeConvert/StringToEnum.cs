using System;

namespace CSharpNote.Data.ProjectMethod.SubClass.ORM.TypeConvert
{
    /// <summary>
    /// 字串轉Enum
    /// </summary>
    public class StringToEnum
    {
        public TEnum Convert<TEnum>(string input)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), input, true);
        }
    }
}