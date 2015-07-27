using System;

namespace CSharpNote.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class , AllowMultiple = true)]
    public class RequiredAttribute : Attribute
    {
        public RequiredAttribute()  
        {
        }
    }
}