using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.DataAccess.CQRS.Queries.ReceivedLetters
{
    public class GetReceivedLetterQuery : QueryBase<ReceivedLetter>
    {
        public int Id { get; set; }
        public override async Task<ReceivedLetter> Execute(VerumContext context)
        {
            var receivedLetter = await context.ReceivedLetters.SingleOrDefaultAsync(x => x.Id == Id);
            return receivedLetter;
        }
    }
}
