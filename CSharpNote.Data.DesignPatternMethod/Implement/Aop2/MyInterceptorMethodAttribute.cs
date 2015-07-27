using System;

namespace CSharpNote.Data.DesignPattern.Implement
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class MyInterceptorMethodAttribute : Attribute { }
}