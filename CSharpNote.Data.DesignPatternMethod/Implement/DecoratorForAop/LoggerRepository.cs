namespace CSharpNote.Data.DesignPatternMethod.Implement.DecoratorForAop
{
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
}