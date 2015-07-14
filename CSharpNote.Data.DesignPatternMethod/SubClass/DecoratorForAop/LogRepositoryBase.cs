namespace CSharpNote.Data.DesignPatternMethod.SubClass.DecoratorForAop
{
    public abstract class LogRepositoryBase<TLogger> : IRepository
        where TLogger : ILogger
    {
        private readonly RepositoryBase repository;
        private readonly TLogger logger;

        protected LogRepositoryBase(RepositoryBase repository, TLogger logger)
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
}