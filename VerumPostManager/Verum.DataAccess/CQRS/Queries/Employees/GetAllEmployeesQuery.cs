using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verum.DataAccess.Entities;

namespace Verum.DataAccess.CQRS.Queries.Employees
{
    public class GetAllEmployeesQuery : QueryBase<List<Employee>>
    {
        public override async Task<List<Employee>> Execute(VerumContext context)
        {
            var employees = await context.Employees.ToListAsync();
            return employees;
        }
    }
}
