using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.Aop
{
    interface IConcern<T>
    {
        T This { get; }
    }

    public class Concern : IConcern<Actor>
    {
        public Actor This { get; set; }

        public Concern(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "Null String";
            }

            This = new Actor(name);
        }
    }
}
