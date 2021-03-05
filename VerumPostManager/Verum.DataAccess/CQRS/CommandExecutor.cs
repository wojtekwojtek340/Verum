using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.CQRS.Commands;

namespace Verum.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly VerumContext context;
        public CommandExecutor(VerumContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Execute(context);
        }
    }
}
