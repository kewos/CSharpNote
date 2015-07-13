using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.DecoratorForAop
{
    public interface IRepository
    {
        void Get();
        void Create();
        void Update();
        void Delete();
    }

    public interface ILogger
    {
        void Log(string msg);
    }

    public class Logger : ILogger
    {
        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public abstract class LogRepositoryBase<TLogger> : IRepository
        where TLogger : ILogger
    {
        private readonly RepositoryBase repository;
        private readonly TLogger logger;

        public LogRepositoryBase(RepositoryBase repository, TLogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        private void Log(string msg)
        {
            logger.Log(msg);
        }

        public void Get()
        {
            Log("Get");
            repository.Get();
        }

        public void Create()
        {
            Log("Create");
            repository.Create();
        }

        public void Update()
        {
            Log("Update");
            repository.Update();
        }

        public void Delete()
        {
            Log("Delete");
            repository.Delete();
        }
    }

    public class LoggerRepository : LogRepositoryBase<Logger>
    {
        public LoggerRepository(RepositoryBase repository)
            : base(repository, new Logger())
        {
        }

        public LoggerRepository(RepositoryBase repository, Logger logger)
            : base(repository, logger)
        { 
        }
    }

    public abstract class RepositoryBase : IRepository
    {
        public void Get()
        {
            Console.WriteLine("Get Item");
        }

        public void Create()
        {
            Console.WriteLine("Create Item");
        }

        public void Update()
        {
            Console.WriteLine("Update Item");
        }

        public void Delete()
        {
            Console.WriteLine("Delete Item");
        }
    }
}
