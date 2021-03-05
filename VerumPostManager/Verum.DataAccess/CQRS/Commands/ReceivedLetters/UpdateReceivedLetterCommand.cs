using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.DataAccess.CQRS.Commands.ReceivedLetters
{
    public class UpdateReceivedLetterCommand : CommandBase<ReceivedLetter, ReceivedLetter>
    {
        public override async Task<ReceivedLetter> Execute(VerumContext context)
        {
            context.ReceivedLetters.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
