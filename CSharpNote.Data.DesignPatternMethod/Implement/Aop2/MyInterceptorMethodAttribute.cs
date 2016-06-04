using System;

namespace CSharpNote.Data.DesignPattern.Implement.Aop2
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class MyInterceptorMethodAttribute : Attribute
    {
    }
}