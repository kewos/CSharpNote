using System.Collections.Generic;
using System.Reflection;

namespace CSharpNote.Data.DesignPattern.Implement.MemotoPattern
{
    public class Memento
    {
        public Dictionary<PropertyInfo, object> Infomation { get; set; }
    }
}
