namespace CSharpNote.Data.DesignPattern.Implement.DecoratorForAop
{
    public abstract class LogRepositoryBase<TLogger> : IRepository
        where TLogger : ILogger
    {
        private readonly TLogger logger;
        private readonly RepositoryBase repository;

        protected LogRepositoryBase(RepositoryBase repository, TLogger logger)
        {
            this.repository = repository;
            this.logger = logger;
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

        private void Log(string msg)
        {
            logger.Log(msg);
        }
    }
}