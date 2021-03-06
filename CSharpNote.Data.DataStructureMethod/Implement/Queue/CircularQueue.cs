﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpNote.Data.DataStructure.Implement.Queue
{
    public class CircularQueue<T> : ICollection<T>
    {
        private readonly LinkedList<T> linklist;

        public CircularQueue(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentException();
            }

            Capacity = capacity;
            linklist = new LinkedList<T>();
        }

        public int Capacity { get; private set; }

        public bool IsFull
        {
            get { return linklist.Count == Capacity; }
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

        public CircularQueue<T> Enqueue(T item)
        {
            EnqueueItem(item);
            return this;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            return DequeueItem();
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            return linklist.First.Value;
        }

        protected virtual void EnqueueItem(T item)
        {
            if (IsFull)
            {
                linklist.RemoveFirst();
            }

            linklist.AddLast(item);
        }

        protected virtual T DequeueItem()
        {
            var value = linklist.First.Value;
            linklist.RemoveFirst();

            return value;
        }

        #region ICollection<T> Members

        public void Add(T item)
        {
            Enqueue(item);
        }

        public void Clear()
        {
            linklist.Clear();
        }

        public bool Contains(T item)
        {
            return !IsEmpty && linklist.Contains(item);
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

        public bool Remove(T item)
        {
            return linklist.Remove(item);
        }

        #endregion
    }
}