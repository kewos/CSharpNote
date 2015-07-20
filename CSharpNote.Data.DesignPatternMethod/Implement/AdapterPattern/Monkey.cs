using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.AdapterPattern
{
    public class Monkey : IAnimal
    {
        public void Run()
        {
            Console.WriteLine("Im {0}", GetType().Name);
        }
    }
}