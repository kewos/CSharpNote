using System;

namespace CSharpNote.Data.DesignPattern.Implement.AdapterPattern
{
    public class DogAdaptor : AnimalAdaptorBase<IMachine>
    {
        public DogAdaptor(IMachine element)
            : base(element)
        {
        }

        public override void Run()
        {
            Console.WriteLine("Im Dog Like {0}", element.Do());
        }
    }
}