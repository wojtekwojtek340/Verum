using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.DataAccess.CQRS.Commands.SentLetters
{
    public class AddSentLetterCommand : CommandBase<SentLetter, SentLetter>
    {
        public override async Task<SentLetter> Execute(VerumContext context)
        {
            await context.SentLetters.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
