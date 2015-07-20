using System.Collections.Generic;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.FilterPattern
{
    public interface IFilter<TItem>
    {
        IEnumerable<TItem> Filter(IEnumerable<TItem> source);
    }
}
