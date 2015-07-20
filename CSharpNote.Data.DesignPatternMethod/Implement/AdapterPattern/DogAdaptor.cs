using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.AdapterPattern
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