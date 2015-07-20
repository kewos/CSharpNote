using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.AdapterPattern
{
    public class CatAdaptor: AnimalAdaptorBase<IMachine>
    {
        public CatAdaptor(IMachine element)
            : base(element)
        {
        }

        public override void Run()
        {
            Console.WriteLine("Im Cat Like {0}", element.Do());
        }
    }
}