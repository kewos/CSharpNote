namespace CSharpNote.Data.DesignPatternMethod.SubClass.DecoratorForAop
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