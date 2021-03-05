using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.DataAccess.CQRS.Queries.ReceivedLetters
{
    public class GetAllReceivedLettersQuery : QueryBase<List<ReceivedLetter>>
    {
        public override async Task<List<ReceivedLetter>> Execute(VerumContext context)
        {
            var receivedLetters = await context.ReceivedLetters.ToListAsync();
            return receivedLetters;
        }
    }
}
