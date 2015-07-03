using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.ReactPattern
{
    public interface IReactor
    {
        void RegisterHandle(IEventHandler eventHandler);
        void RemoveHandle(IEventHandler eventHandler);
        void HandleEvents();
    }
}
