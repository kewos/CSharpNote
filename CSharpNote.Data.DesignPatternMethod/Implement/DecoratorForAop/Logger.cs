using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.DecoratorForAop
{
    public class Logger : ILogger
    {
        public void Log(string msg)
        {
            Console.WriteLine("log");
        }
    }
}