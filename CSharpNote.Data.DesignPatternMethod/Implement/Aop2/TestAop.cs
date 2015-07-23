using System;

namespace CSharpNote.Data.DesignPatternMethod.Implement
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