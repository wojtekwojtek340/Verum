using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.DataAccess.CQRS.Commands.SentLetters
{
    public class UpdateSentLetterCommand : CommandBase<SentLetter, SentLetter>
    {
        public override async Task<SentLetter> Execute(VerumContext context)
        {
            context.SentLetters.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
