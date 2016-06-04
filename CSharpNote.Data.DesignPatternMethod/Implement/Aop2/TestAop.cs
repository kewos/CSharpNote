using System;

namespace CSharpNote.Data.DesignPattern.Implement.Aop2
{
    [MyInterceptor]
    public class TestAop : ContextBoundObject
    {
        [MyInterceptorMethod]
        public void Display()
        {
            Console.WriteLine("testaop");
        }
    }
}