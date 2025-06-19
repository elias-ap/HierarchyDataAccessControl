using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyDataAccessControl.Data
{
    public class HierarchyDataAccessContextFactory : IDesignTimeDbContextFactory<HierarchyDataAccessContext>
    {
        public HierarchyDataAccessContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HierarchyDataAccessContext>();

            optionsBuilder
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HierarchyDataAccessControl");
            
            return new HierarchyDataAccessContext(optionsBuilder.Options);
        }
    }
}
