using System;

namespace CSharpNote.Data.DesignPattern.Implement
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