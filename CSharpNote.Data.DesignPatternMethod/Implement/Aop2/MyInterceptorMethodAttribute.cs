using System;

namespace CSharpNote.Data.DesignPatternMethod.Implement
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class MyInterceptorMethodAttribute : Attribute { }
}