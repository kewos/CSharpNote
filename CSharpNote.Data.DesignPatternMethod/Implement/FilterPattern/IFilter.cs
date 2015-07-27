using System.Collections.Generic;

namespace CSharpNote.Data.DesignPattern.Implement.FilterPattern
{
    public interface IFilter<TItem>
    {
        IEnumerable<TItem> Filter(IEnumerable<TItem> source);
    }
}
