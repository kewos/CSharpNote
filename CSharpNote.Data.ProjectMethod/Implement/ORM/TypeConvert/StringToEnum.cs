using System;

namespace CSharpNote.Data.Project.Implement.ORM.TypeConvert
{
    /// <summary>
    /// 字串轉Enum
    /// Note：希望Enum可以被Constraint
    /// </summary>
    public class StringToEnum
    {
        public TEnum Convert<TEnum>(string input)
            where TEnum : struct, IConvertible
        {
            if (typeof (TEnum).IsEnum)
            {
                return (TEnum) Enum.Parse(typeof (TEnum), input, true);
            }
            throw new ArgumentException("Convert fail");
        }
    }
}