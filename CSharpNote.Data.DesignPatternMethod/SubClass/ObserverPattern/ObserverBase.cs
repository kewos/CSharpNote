using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.ObserverPattern
{
    public abstract class ObserverBase<T> : IObserver<T>
    {
        public virtual void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public virtual void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public virtual void OnNext(T value)
        {
            throw new NotImplementedException();
        }
    }
}