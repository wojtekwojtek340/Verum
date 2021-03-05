using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.DataAccess.CQRS.Queries.SentLetters
{
    public class GetAllSentLettersQuery : QueryBase<List<SentLetter>>
    {
        public override async Task<List<SentLetter>> Execute(VerumContext context)
        {
            var sentLetters = await context.SentLetters.ToListAsync();
            return sentLetters;
        }
    }
}
