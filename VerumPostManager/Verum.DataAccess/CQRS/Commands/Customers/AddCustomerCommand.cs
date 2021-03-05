using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.DataAccess.CQRS.Commands.Customers
{
    public class AddCustomerCommand : CommandBase<Customer, Customer>
    {
        public override async Task<Customer> Execute(VerumContext context)
        {
            await context.Customers.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
