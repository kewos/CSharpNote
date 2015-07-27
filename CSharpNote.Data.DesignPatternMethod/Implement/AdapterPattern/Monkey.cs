using System;

namespace CSharpNote.Data.DesignPattern.Implement.AdapterPattern
{
    public class Monkey : IAnimal
    {
        public void Run()
        {
            Console.WriteLine("Im {0}", GetType().Name);
        }
    }
}