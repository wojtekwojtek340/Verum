using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.DataAccess.CQRS.Queries.Customers
{
    public class GetCustomerQuery : QueryBase<Customer>
    {
        public int Id { get; set; }
        public override async Task<Customer> Execute(VerumContext context)
        {
            var customer = await context.Customers.SingleOrDefaultAsync(x => x.Id == Id);
            return customer;

        }
    }
}
