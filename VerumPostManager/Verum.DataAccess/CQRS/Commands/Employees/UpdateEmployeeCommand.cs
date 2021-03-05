using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.DataAccess.CQRS.Commands.Employees
{
    public class UpdateEmployeeCommand : CommandBase<Employee, Employee>
    {
        public override async Task<Employee> Execute(VerumContext context)
        {
            context.Employees.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
