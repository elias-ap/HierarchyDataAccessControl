using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HierarchyDataAccessControl.Models;
using Microsoft.EntityFrameworkCore.Internal;
using HierarchyDataAccessControl.Data.TypesConfiguration;

namespace HierarchyDataAccessControl.Data
{
    public class HierarchyDataAccessContext : DbContext
    {
        public DbSet<HierarchyNode> Nodes { get; set; }
        public DbSet<HierarchyNodeType> Types { get; set; }

        public HierarchyDataAccessContext(DbContextOptions<HierarchyDataAccessContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(HierarchyDataAccessContext).Assembly);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) { }

        public IEnumerable<HierarchyNodeType> GetAllTypes()
        {
            try
            {
                return Types
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
