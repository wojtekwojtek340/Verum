using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verum.DataAccess.CQRS.Commands.Employees
{
    public class DeleteEmployeeCommand : CommandBase<int, int>
    {
        public override async Task<int> Execute(VerumContext context)
        {
            var entity = await context.Employees.FindAsync(Parameter);
            context.Employees.Remove(entity);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
