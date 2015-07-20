using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpNote.Data.DataStructureMethod.Implement.Buffer
{
    /// <summary>
    /// FIFO
    /// </summary>
    public class CircularBuffer<T> : IBuffer<T>, IEnumerable<T>, IEnumerable
    {
        private T[] buffer;
        private int start;
        private int end;

        #region property
        public int Capacity
        {
            get
            {
                return buffer.Length;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return end == start;
            }
        }

        public bool IsFull
        {
            get
            {
                return (end + 1) % Capacity == start;
            }
        }
        #endregion

        public CircularBuffer(int capacity = 10)
        {
            if (capacity <= 1)
            {
                throw new ArgumentException("InvalidArgument!!");
            } 

            buffer = new T[capacity];
            start = end = 0;
        }

        public void Write(T[] items)
        {
            foreach (var item in items)
            {
                Write(item);
            }
        }

        public void Write(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Write(item);
            }
        }

        public void Write(T value)
        {
            end = (end + 1) % Capacity;
            buffer[end] = value;

            //at same position start + 1
            if (end.Equals(start))
            {
                start = (start + 1) % Capacity;
            }
        }

        public T Read()
        {
            T result = buffer[start];
            start = (start + 1) % Capacity;

            return result;
        }

        #region IEnumerable<T> Member
        public IEnumerator<T> GetEnumerator()
        {
            for (var index = start; ; index = (index + 1) % Capacity)
            {
                yield return buffer[index];
                if (index == end)
                    yield break;
            }
        }
        #endregion

        #region IEnumerable Member
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
