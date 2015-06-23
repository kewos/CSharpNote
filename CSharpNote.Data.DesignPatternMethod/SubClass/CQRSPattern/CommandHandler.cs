using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.CQRSPattern
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }

    public class CommandHandler : ICommandHandler<IComment>
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

        public void Handle(IComment command)
        {
            
        }
    }
}
