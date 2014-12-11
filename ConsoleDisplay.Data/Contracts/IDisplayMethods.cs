using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleDisplay.Data.Contracts 
{
    public interface IDisplayMethods
    {
        List<MethodInfo> MethodInfos { get; }
    }
}
