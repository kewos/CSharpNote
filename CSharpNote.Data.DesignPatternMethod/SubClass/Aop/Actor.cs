using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.Aop
{
    interface IActor
    {
        string Name { get; set; }
    }

    public class Actor : IActor
    {
        public string Name { get; set; }
        public Actor(string name)
        {
            this.Name = name;
        }
    }
}
