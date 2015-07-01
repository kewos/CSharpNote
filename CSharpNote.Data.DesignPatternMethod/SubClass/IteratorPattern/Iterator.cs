using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.IteratorPattern
{
    public class Iterator<TItem> : IIterator<TItem>
    {
        private readonly IEnumerable<TItem> aggregate;
        private int currentIndex;
        private readonly int max;

        public Iterator(IEnumerable<TItem> aggregate)
        {
            this.aggregate = aggregate;

            currentIndex = 0;
            max = aggregate.Count();
        }

        public bool hasNext()
        {
            return currentIndex < max;
        }

        public TItem Next()
        {
            if (!hasNext()) 
            {
                throw new Exception("NoNext");
            }

            return aggregate.Skip(currentIndex++).First();
        }
    }
}
