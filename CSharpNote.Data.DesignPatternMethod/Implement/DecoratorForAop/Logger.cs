using System;

namespace CSharpNote.Data.DesignPattern.Implement.DecoratorForAop
{
    public class Logger : ILogger
    {
        public void Log(string msg)
        {
            Console.WriteLine("log");
        }
    }
}