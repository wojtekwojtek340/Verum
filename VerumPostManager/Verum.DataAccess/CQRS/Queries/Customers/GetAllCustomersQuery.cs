using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.DataAccess.CQRS.Queries.Customers
{
    public class GetAllCustomersQuery : QueryBase<List<Customer>>
    {
        public override async Task<List<Customer>> Execute(VerumContext context)
        {
            var customers = await context.Customers.ToListAsync();
            return customers;
        }
    }
}
