using System;
using System.Collections.Generic;
using CSharpNote.Common.Extensions;

namespace CSharpNote.Data.DesignPattern.Implement.ObserverPattern
{
    public abstract class ObservableBase<T> : IObservable<T>
    {
        private readonly IList<IObserver<T>> observers;

        public ObservableBase()
        {
            observers = new List<IObserver<T>>();
        }

        public virtual IDisposable Subscribe(IObserver<T> observer)
        {
            observers.Add(observer);
            return new Unsubscribe(() =>
            {
                if (observers != null && observers.Contains(observer))
                    observers.Remove(observer);
            });
        }

        public virtual void Notify(T obj)
        {
            observers.ForEach(observer => observer.OnNext(obj));
        }

        public class Unsubscribe : IDisposable
        {
            private readonly Action unsubscribe;

            public Unsubscribe(Action unsubscribe)
            {
                this.unsubscribe = unsubscribe;
            }

            public void Dispose()
            {
                if (unsubscribe != null)
                    unsubscribe();
            }
        }
    }
}