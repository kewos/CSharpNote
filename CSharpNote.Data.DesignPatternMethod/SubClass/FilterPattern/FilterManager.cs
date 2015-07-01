using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.FilterPattern
{
    public class FilterManager<TItem>
    {
        private Dictionary<Type, IFilter<TItem>> filterDic;

        public FilterManager()
        {
            filterDic = new Dictionary<Type, IFilter<TItem>>();
        }

        public void AddFilter<TFilter>()
            where TFilter : IFilter<TItem>, new()
        {
            var type = typeof(TFilter);

            if (!filterDic.ContainsKey(type))
            {
                filterDic[type] = new TFilter();
            }
        }

        public IEnumerable<TItem> ExecuteFilter<TFilter>(IEnumerable<TItem> source)
            where TFilter : IFilter<TItem>, new()
        {
            var type = typeof(TFilter);

            if (!filterDic.ContainsKey(type))
            {
                filterDic[type] = new TFilter();
            }

            return filterDic[type].Filter(source);
        }
    }
}
