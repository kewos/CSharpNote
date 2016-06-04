using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.MemotoPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class MemotoPatternImplement : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var originator = new Charactor();
            var caretaker = new Caretaker();

            originator.Atk = 1;
            originator.Hp = 100;
            originator.Weapon = "Sword";
            caretaker.SetMemento(originator.CreateMemento());

            originator.Atk = 3;
            originator.Hp = 300;
            originator.Weapon = "Sword";
            caretaker.SetMemento(originator.CreateMemento());

            originator.Atk = 2;
            originator.Hp = 200;
            originator.Weapon = "Axe";
            caretaker.SetMemento(originator.CreateMemento());

            originator.Atk = 4;
            originator.Hp = 400;
            originator.Weapon = "Bow";
            caretaker.SetMemento(originator.CreateMemento());

            foreach (var memoto in caretaker.GetAll())
            {
                originator.RestoreMemento(memoto);
                Console.WriteLine("Atk:{0} Hp:{1} Weapon:{2}", originator.Atk, originator.Hp, originator.Weapon);
            }
        }
    }
}