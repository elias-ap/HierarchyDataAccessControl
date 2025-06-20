using HierarchyDataAccessControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Xml.Linq;

namespace HierarchyDataAccessControl.Data
{
    public class HierarchyDataAccessContext : DbContext
    {
        public DbSet<HierarchyNode> Nodes { get; set; }
        public DbSet<HierarchyNodeType> Types { get; set; }
        public DbSet<User> Users { get; set; }

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

        public IEnumerable<HierarchyNode> GetAllHierarchyNodes()
        {
            try
            {
                return Nodes
                    .AsNoTracking()
                    .Include(hn => hn.ChildrenNodes)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IEnumerable<HierarchyNode> GetAllFirstLevelHierarchyNodes()
        {
            try
            {
                return Nodes
                    .AsNoTracking()
                    .Where(hn => hn.TypeId == 1)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return Users
                    .AsNoTracking()
                    .Include(u => u.Groups)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<HierarchyNode> GetAllNodesHierarchically()
        {
            try
            {
                var nodes = Nodes
                    .AsNoTracking()
                    .Where(n => n.TypeId == 1)
                    .ToList();

                Parallel.ForEach(nodes, n => LoadChildrenNodes(n));

                return nodes;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void LoadChildrenNodes(HierarchyNode node)
        {
            node.ChildrenNodes = Nodes
                .AsNoTracking()
                .Where(n => n.ParentId == node.Id)
                .ToList();

            foreach (var child in node.ChildrenNodes)
            {
                LoadChildrenNodes(child);
            }
        }

    }
}
