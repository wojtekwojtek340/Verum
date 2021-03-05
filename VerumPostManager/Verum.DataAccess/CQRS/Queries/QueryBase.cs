using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verum.DataAccess.CQRS.Queries
{
    public abstract class QueryBase<TResult>
    {
        public abstract Task<TResult> Execute(VerumContext context);
    }
}
