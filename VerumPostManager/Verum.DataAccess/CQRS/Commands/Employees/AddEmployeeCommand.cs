using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.DataAccess.CQRS.Commands.Employees
{
    public class AddEmployeeCommand : CommandBase<Employee, Employee>
    {
        public override async Task<Employee> Execute(VerumContext context)
        {
            await context.Employees.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
