using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.FilterPattern
{
    public interface IFilter<TItem>
    {
        IEnumerable<TItem> Filter(IEnumerable<TItem> source);
    }
}
