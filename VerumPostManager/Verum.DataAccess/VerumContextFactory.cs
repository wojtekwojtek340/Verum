using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verum.DataAccess
{
    public class VerumContextFactory : IDesignTimeDbContextFactory<VerumContext>
    {
        public VerumContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<VerumContext>();

            options.UseSqlServer("Server=DESKTOP-TH6F0L5;Initial Catalog=VerumDb;User ID=Verum;password=Verum;Integrated Security=True;Trusted_Connection=True;");

            return new VerumContext(options.Options);
        }
    }
}
