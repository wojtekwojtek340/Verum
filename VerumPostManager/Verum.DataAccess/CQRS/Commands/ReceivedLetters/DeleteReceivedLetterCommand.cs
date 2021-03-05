using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verum.DataAccess.CQRS.Commands.ReceivedLetters
{
    public class DeleteReceivedLetterCommand : CommandBase<int, int>
    {
        public override async Task<int> Execute(VerumContext context)
        {
            var entity = await context.ReceivedLetters.FindAsync(Parameter);
            context.ReceivedLetters.Remove(entity);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
