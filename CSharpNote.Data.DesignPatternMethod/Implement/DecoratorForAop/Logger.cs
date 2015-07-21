using System;

namespace CSharpNote.Data.DesignPatternMethod.Implement.DecoratorForAop
{
    public class Logger : ILogger
    {
        public void Log(string msg)
        {
            Console.WriteLine("log");
        }
    }
}