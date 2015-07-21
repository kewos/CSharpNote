using System.Collections.Generic;
using System.Reflection;

namespace CSharpNote.Data.DesignPatternMethod.Implement.MemotoPattern
{
    public class Memento
    {
        public Dictionary<PropertyInfo, object> Infomation { get; set; }
    }
}
