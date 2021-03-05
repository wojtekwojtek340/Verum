using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.DataAccess.CQRS.Queries.SentLetters
{
    public class GetSentLetterQuery : QueryBase<SentLetter>
    {
        public int Id { get; set; }
        public override async Task<SentLetter> Execute(VerumContext context)
        {
            var sentLetter = await context.SentLetters.SingleOrDefaultAsync(x => x.Id == Id);
            return sentLetter;
        }
    }
}
