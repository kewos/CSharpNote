using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpNote.Data.DesignPattern.Implement.IteratorPattern
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

        public bool HasNext()
        {
            return currentIndex < max;
        }

        public TItem Next()
        {
            if (!HasNext()) 
            {
                throw new Exception("NoNext");
            }

            return aggregate.Skip(currentIndex++).First();
        }
    }
}
