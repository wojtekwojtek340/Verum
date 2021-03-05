using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.DataAccess.CQRS.Commands.Customers
{
    public class UpdateCustomerCommand : CommandBase<Customer, Customer>
    {
        public override async Task<Customer> Execute(VerumContext context)
        {
            context.Customers.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
