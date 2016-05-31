namespace CSharpNote.Data.DesignPattern.Implement.CQRSPattern
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }

    public class CommandHandler : ICommandHandler<Comment>
    {
        private readonly CheckCommandService commandService;

        public CommandHandler()
            : this(new CheckCommandService())
        {
        }

        public CommandHandler(CheckCommandService commandService)
        {
            this.commandService = commandService;
        }

        public void Handle(Comment command)
        {
        }
    }
}