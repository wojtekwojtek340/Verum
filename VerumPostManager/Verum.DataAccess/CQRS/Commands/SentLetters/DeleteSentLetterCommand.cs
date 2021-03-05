using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verum.DataAccess.CQRS.Commands.SentLetters
{
    public class DeleteSentLetterCommand : CommandBase<int, int>
    {
        public override async Task<int> Execute(VerumContext context)
        {
            var entity = await context.SentLetters.FindAsync(Parameter);
            context.SentLetters.Remove(entity);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
