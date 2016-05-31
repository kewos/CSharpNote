using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpNote.Data.DataStructure.Implement.Queue
{
    public class Deque<T> : ICollection<T>
    {
        private readonly LinkedList<T> linklist;

        public Deque()
        {
            linklist = new LinkedList<T>();
        }

        public Deque(IEnumerable<T> collection)
        {
            linklist = new LinkedList<T>(collection);
        }

        public T Head
        {
            get
            {
                Vaildate();
                return linklist.First.Value;
            }
        }

        public T Talil
        {
            get
            {
                Vaildate();
                return linklist.Last.Value;
            }
        }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return linklist.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        private void Vaildate()
        {
            if (linklist.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        public Deque<T> EnqueueHead(T item)
        {
            Vaildate();
            EnqueueHeadItem(item);
            return this;
        }

        public Deque<T> EnqueueTail(T item)
        {
            Vaildate();
            EnqueueTailItem(item);
            return this;
        }

        public T DequeueHead()
        {
            Vaildate();
            return DequeueHeadItem();
        }

        public T DequeueTail()
        {
            Vaildate();
            return DequeueTailItem();
        }

        protected virtual void EnqueueHeadItem(T item)
        {
            linklist.AddFirst(item);
        }

        protected virtual void EnqueueTailItem(T item)
        {
            linklist.AddLast(item);
        }

        protected virtual T DequeueHeadItem()
        {
            var value = linklist.First.Value;
            linklist.RemoveFirst();
            return value;
        }

        protected virtual T DequeueTailItem()
        {
            var value = linklist.Last.Value;
            linklist.RemoveLast();
            return value;
        }

        #region ICollection<T> Members

        public void Add(T item)
        {
            throw new NotImplementedException("NoImplement");
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException("NoImplement");
        }

        public void Clear()
        {
            linklist.Clear();
        }

        public bool Contains(T item)
        {
            return linklist.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            linklist.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return linklist.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion
    }
}