using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.CQRS.Queries;

namespace Verum.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly VerumContext context;

        public QueryExecutor(VerumContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> querry)
        {
            throw new NotImplementedException();
        }
    }
}
