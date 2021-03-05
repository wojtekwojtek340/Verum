using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verum.DataAccess.CQRS.Commands.Customers
{
    public class DeleteCustomerCommand : CommandBase<int, int>
    {
        public override async Task<int> Execute(VerumContext context)
        {
            var entity = await context.Customers.FindAsync(Parameter);
            context.Customers.Remove(entity);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
