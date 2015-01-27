using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplay.Data.DesignPatternMethod.SubClass
{
    public interface ISubject
    {
        void Regist(IObserver observer);
        void Remove(IObserver observer);
        void NotifyObserver(string msg);
    }

    public interface IObserver
    {
        void update(string msg);
    }

    public class Man : IObserver
    {
        private String Name;

        public Man(string name)
        {
            Name = name;
        }

        public void update(string msg)
        {
            Console.WriteLine("{0}看了這篇文章{1}他覺得很無聊", Name, msg);
        }
    }

    public class Woman : IObserver
    {
        private String Name;

        public Woman(string name)
        {
            Name = name;
        }

        public void update(string msg)
        {
            Console.WriteLine("{0}看了這篇文章{1}她覺得很有趣", Name, msg);
        }
    }

    public class Bloger : ISubject
    {
        private List<IObserver> observers;

        public Bloger()
        {
            if (observers == null) observers = new List<IObserver>();
        }

        public void Regist(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            if (observers.Contains(observer)) observers.Remove(observer);
        }

        public void NotifyObserver(string msg)
        {
            observers.ForEach(observer => observer.update(msg));
        }
    }
}
