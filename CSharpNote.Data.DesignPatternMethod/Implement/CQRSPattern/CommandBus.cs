namespace CSharpNote.Data.DesignPattern.Implement.CQRSPattern
{
    public interface ICommanBus
    {
        void Send<TCommand>(TCommand command)
            where TCommand : ICommand;
    }

    //public class CommandBus : ICommanBus
    //{
    //    private readonly CommandHandler handler;

    //    public CommandBus()
    //        : this(new CommandHandler())
    //    {
    //    }

    //    public CommandBus(CommandHandler handler)
    //    {
    //        this.handler = handler;
    //    }

    //    public void Send<TCommand>(TCommand command)
    //        where TCommand : IComment, ICommand
    //    {
    //        handler.Handle(command);
    //    }
    //}
}