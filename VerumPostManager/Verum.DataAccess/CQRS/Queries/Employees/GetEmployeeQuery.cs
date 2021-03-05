using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.DataAccess.CQRS.Queries.Employees
{
    public class GetEmployeeQuery : QueryBase<Employee>
    {
        public int Id { get; set; }
        public override async Task<Employee> Execute(VerumContext context)
        {
            var employee = await context.Employees.SingleOrDefaultAsync(x => x.Id == Id);
            return employee;
        }
    }
}
