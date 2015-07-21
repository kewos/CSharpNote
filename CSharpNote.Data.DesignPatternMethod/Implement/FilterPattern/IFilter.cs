using System.Collections.Generic;

namespace CSharpNote.Data.DesignPatternMethod.Implement.FilterPattern
{
    public interface IFilter<TItem>
    {
        IEnumerable<TItem> Filter(IEnumerable<TItem> source);
    }
}
