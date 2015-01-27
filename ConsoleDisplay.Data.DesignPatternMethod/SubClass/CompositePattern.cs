using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplay.Data.DesignPatternMethod.SubClass
{
    public interface IStuff
    {
        void Opertaion();
    }

    public class Manager : IStuff
    {
        public List<IStuff> supervisors = new List<IStuff>();

        public void Opertaion()
        {
            Console.WriteLine("Im Manager");
            supervisors.ForEach(supervisor => supervisor.Opertaion());
        }
    }

    public class Supervisor : IStuff
    {
        public List<IStuff> workers = new List<IStuff>();

        public void Opertaion()
        {
            Console.WriteLine("---Im Supervisor");
            workers.ForEach(worker => worker.Opertaion());
        }
    }

    public class Worker : IStuff
    {
        public void Opertaion()
        {
            Console.WriteLine("------Im Worker");
        }
    }
}
