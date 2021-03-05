using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.DataAccess.CQRS.Commands.ReceivedLetters
{
    public class AddReceivedLetterCommand : CommandBase<ReceivedLetter, ReceivedLetter>
    {
        public override async Task<ReceivedLetter> Execute(VerumContext context)
        {
            await context.ReceivedLetters.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
