using System;

namespace CSharpNote.Data.DesignPatternMethod.Implement.AdapterPattern
{
    public class Monkey : IAnimal
    {
        public void Run()
        {
            Console.WriteLine("Im {0}", GetType().Name);
        }
    }
}