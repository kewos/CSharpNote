using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.MemotoPattern
{
    public class Charactor : OriginatorBase
    {
        public int Hp { get; set; }
        public int Atk { get; set; }
        public string Weapon { get; set; }
    }
}
